using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_10_Block : MonoBehaviour
{
    [SerializeField] Sprite[] block_sprites;
    [SerializeField] SpriteRenderer current_sprite;

    [SerializeField] GameObject partical_prefab;

    private Level_10_Spacial_block_spawn level_10_block_spawner;
    private Score_UI_Manager score_ui_manager;
    private int count_damage = 0;

    private Level_6_Game_Mechanics level_6_game_mechanics;

    private Audio_Manager audio_manager;
    void Start()
    {
     
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
        current_sprite = GetComponent<SpriteRenderer>();

        if (Scene_Loader.scene_index == 11)
        {
            level_10_block_spawner = FindObjectOfType<Level_10_Spacial_block_spawn>().GetComponent<Level_10_Spacial_block_spawn>();
            score_ui_manager = FindObjectOfType<Score_UI_Manager>().GetComponent<Score_UI_Manager>();
        }
        else
        {
            level_6_game_mechanics = FindObjectOfType<Level_6_Game_Mechanics>().GetComponent<Level_6_Game_Mechanics>();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage_Block();
    }

    private void Damage_Block()
    {
        
        if (count_damage == 0)
        {
            audio_manager.Play("block_1");

            current_sprite.sprite = block_sprites[3]; 
            count_damage++;
        }
        else
        {
            if(Scene_Loader.scene_index == 11)
                audio_manager.Play("block_1");
            else
                audio_manager.Play("block_top_2");


            if (Scene_Loader.scene_index == 6)
               level_6_game_mechanics.hit_detected_level6 = true;

            if (Scene_Loader.scene_index == 11)
            {
                score_ui_manager.Increase_Score(5);
                level_10_block_spawner.count_blocks--;
            }

            Instantiate(partical_prefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
