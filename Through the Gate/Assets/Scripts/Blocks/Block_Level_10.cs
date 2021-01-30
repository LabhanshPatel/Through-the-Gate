using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Level_10 : MonoBehaviour
{
    [SerializeField] Sprite[] block_sprites;
    [SerializeField] SpriteRenderer current_sprite;

    [SerializeField] float move_speed;

    [SerializeField] GameObject partical_prefab;

    private Transform ball_pos;
    private Rigidbody2D ball_rb;

    private int count_damage = 0;
    private Level_10_Game_Mechanics level_10_game_mechanics;
    private Score_UI_Manager score_ui_manager;

    private float block_extents;
    private Audio_Manager audio_manager;
    void Start()
    {
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
        current_sprite = GetComponent<SpriteRenderer>();          
        level_10_game_mechanics = FindObjectOfType<Level_10_Game_Mechanics>();

        ball_pos = FindObjectOfType<Ball>().GetComponent<Transform>();
        ball_rb = FindObjectOfType<Ball>().GetComponent<Rigidbody2D>();
        block_extents = GetComponent<BoxCollider2D>().bounds.extents.x;
        score_ui_manager = FindObjectOfType<Score_UI_Manager>().GetComponent<Score_UI_Manager>();
    }

    private void Update()
    {
        // Block Movement
        if (ball_pos.position.y > 0 && ball_rb.velocity.y > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(ball_pos.position.x, transform.position.y),
                move_speed * Time.deltaTime);
        }

        transform.position = new Vector2(Mathf.Clamp
        (transform.position.x, -10 + block_extents, 10 - block_extents), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage_Block();
    }

    private void Damage_Block()
    {
       
        if (count_damage == 0)
        {
            audio_manager.Play("Level_10_block_1");
            current_sprite.sprite = block_sprites[1]; // put "count_damage" here
            count_damage++;
        }
        else if (count_damage == 1)
        {
            audio_manager.Play("Level_10_block_1");
            current_sprite.sprite = block_sprites[3];
            count_damage++;
        }
        else if (count_damage == 2)
        {
            audio_manager.Play("Level_10_block_1");
            current_sprite.sprite = block_sprites[4];
            count_damage++;
        }
        else
        {
            audio_manager.Play("Level_10_block_2");

            score_ui_manager.Increase_Score(20);

            level_10_game_mechanics.hit_detected_level10 = true;

            FindObjectOfType<Level_10_Spacial_block_spawn>().GetComponent<Level_10_Spacial_block_spawn>().is_destroyed = true;


            Instantiate(partical_prefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
