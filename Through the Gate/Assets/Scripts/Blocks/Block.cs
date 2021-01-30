using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Audio_Manager audio_manager;

    [SerializeField] GameObject partical_prefab;

    // block_sprites is an array which stores all layers of breakable sprites of a perticular block.   
    [SerializeField] Sprite[] block_sprites;
    [SerializeField] SpriteRenderer current_sprite;

    public static bool block_has_been_destroyed = false;

    // Here X1,X2,X3 and X4 are indicating four parallel horizontal spaces on screen where blocks will instantiate.
    private Spawn_Manager_X1 spawn_manager_X1;
    private Spawn_Manager_X2 spawn_manager_X2;
    private Spawn_Manager_X3 spawn_manager_X3;
    private Spawn_Manager_X4 spawn_manager_X4;

 

    private Transform ball_position;

    private Level_1_Game_Mechanics level_1_game_mechanics;
    private Level_2_Game_Mechanics level_2_game_mechanics;
    private Level_3_Game_Mechanics level_3_game_mechanics;
    private Level_5_Game_Mechanics level_5_game_mechanics;
    private Level_8_Game_Mechanics level_8_game_mechanics;
   


    // count_damage variable counts the no. of time a block has been hit by the ball.
    private int count_damage;


    void Start()
    {
        if(Scene_Loader.scene_index != 8 && Scene_Loader.scene_index != 9)
        ball_position = GameObject.Find("Ball").GetComponent<Transform>();

        spawn_manager_X1 = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager_X1>();
        spawn_manager_X2 = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager_X2>();
        spawn_manager_X3 = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager_X3>();
        spawn_manager_X4 = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager_X4>(); 

        current_sprite = GetComponent<SpriteRenderer>();
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();


        if (Scene_Loader.scene_index == 1)
        {
            level_1_game_mechanics = FindObjectOfType<Level_1_Game_Mechanics>();
        }
        else if (Scene_Loader.scene_index == 2)
        {
            level_2_game_mechanics = FindObjectOfType<Level_2_Game_Mechanics>();
        }
        else if(Scene_Loader.scene_index == 3)
        {
            level_3_game_mechanics = FindObjectOfType<Level_3_Game_Mechanics>();
        }
        else if (Scene_Loader.scene_index == 5)
        {
            level_5_game_mechanics = FindObjectOfType<Level_5_Game_Mechanics>();
        }
        else if (Scene_Loader.scene_index == 9)
        {
            level_8_game_mechanics = FindObjectOfType<Level_8_Game_Mechanics>();
        }
    

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {     
        Damage_Block();
    }

    private void Damage_Block()
    {
        // Hitting the block more and more until it breaks. Changing sprites to show the amount of damage block has taken. 

     /* if (count_damage == 0) {
            current_sprite.sprite = block_sprites[count_damage];
            count_damage++;
        }
        else if (count_damage == 1) {
            current_sprite.sprite = block_sprites[count_damage];
            count_damage++;
        }
        else if (count_damage == 2) {
            current_sprite.sprite = block_sprites[count_damage];
            count_damage++;
        }
        else if (count_damage == 3) {         
            current_sprite.sprite = block_sprites[count_damage];
            count_damage++;
        }       */
        if (count_damage == 0) 
        {
           
            audio_manager.Play("block_1");

            current_sprite.sprite = block_sprites[3]; // put "count_damage" here
            count_damage++; 
        }
        else
        {
            if(gameObject.tag == "Block_Top")
            {
                if(Scene_Loader.scene_index != 10)
                audio_manager.Play("block_top_2");
                else
                    audio_manager.Play("block_1");

            }
            else
            {
                audio_manager.Play("block_bottom_2");
            }


            // Finally, destroying the block.
            Reduce_Count();

            Hit_Ditected();

         // Related to Score UI system.  
            if(this.gameObject.tag == "Block_Bottom")
                 block_has_been_destroyed = true;

            Instantiate(partical_prefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject);

        }
    }

 /* Here(in "Reduce_Count" method) we are keeping track of total no. of blocks instantiated in that perticular space. 
    If the amount of blocks exceeds the space available for instantiation, program will stuck inside a infinite loop
    and we definetly don't want that to happen.
 
    Know exactly what's happening in Spawnmanager scripts */
    private void Reduce_Count()
    {
        if (transform.position.y == 11f)         // X1 = 10f
            spawn_manager_X1.count_blocks_X1--;
        else if (transform.position.y == 9f)     // X2 = 6f
            spawn_manager_X2.count_blocks_X2--;
        else if (transform.position.y == -9f)    // X3 = -6f
            spawn_manager_X3.count_blocks_X3--;
        else if (transform.position.y == -11f)    // X4 = -10f
            spawn_manager_X4.count_blocks_X4--;
        else if(transform.position.y == 14f)
            spawn_manager_X1.count_blocks_X1--; // for level_8

    }

    private void Hit_Ditected()
    {
        // switching hit_detected variable's to true, when collision is detected.
        if (Scene_Loader.scene_index == 1)
        {
            // "ball_position.position.y > 0" means that ball is above the paddle
            if (ball_position.position.y > 0)           
                level_1_game_mechanics.hit_detected_level1_top = true;                   
            else            
                level_1_game_mechanics.hit_detected_level1_bottom = true;                         
        }
        else if (Scene_Loader.scene_index == 2)
        {
            if (ball_position.position.y > 0)
                level_2_game_mechanics.hit_detected_level2_top = true;
            else
                level_2_game_mechanics.hit_detected_level2_bottom = true;
        }         
        else if (Scene_Loader.scene_index == 3)
        {
            if (level_3_game_mechanics.can_do_move_mechanics)
                level_3_game_mechanics.hit_detected_level3 = true;
        }
        else if (Scene_Loader.scene_index == 5)
        {
            level_5_game_mechanics.hit_detected_level5 = true;
        }
        else if (Scene_Loader.scene_index == 9)
        {
            level_8_game_mechanics.hit_detected_level8 = true;
        }
       

    }

  
}
