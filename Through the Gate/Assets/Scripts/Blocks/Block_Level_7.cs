using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Level_7 : MonoBehaviour
{
    [SerializeField] Sprite block_sprites;
    [SerializeField] SpriteRenderer current_sprite;

    [SerializeField] GameObject partical_prefab;


    private Score_UI_Manager score_ui_manager;
    private int count_damage =0;

    private Audio_Manager audio_manager;
    void Start()
    {
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();

        current_sprite = GetComponent<SpriteRenderer>();

        score_ui_manager = FindObjectOfType<Score_UI_Manager>().GetComponent<Score_UI_Manager>();
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
        if (count_damage == 0) {
            audio_manager.Play("block_1");
            current_sprite.sprite = block_sprites;// put "count_damage" here
        count_damage++; 
        }
        else
        {
            audio_manager.Play("block_bottom_2");
            score_ui_manager.Increase_Score(5);

            Instantiate(partical_prefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

}
