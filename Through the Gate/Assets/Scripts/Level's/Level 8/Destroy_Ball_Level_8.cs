using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Ball_Level_8 : MonoBehaviour
{

    private Scene_Loader scene_loader;
    private Score_UI_Manager score_ui_manager;
    private SpriteRenderer bottom_sprite;

    private bool destroy_now = false;

    private Audio_Manager audio_manager;
    void Start()
    {
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
        scene_loader = FindObjectOfType<Scene_Loader>().GetComponent<Scene_Loader>();
        score_ui_manager = FindObjectOfType<Score_UI_Manager>().GetComponent<Score_UI_Manager>();
        bottom_sprite = GameObject.Find("Bottom Support").GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroy_now)
        {
            if (collision.gameObject.tag == "Top" || collision.gameObject.tag == "Block_Top")
                Destroy(this.gameObject );
        }

        if (collision.gameObject.tag == "Player")
        {
            audio_manager.Play("Player");
            destroy_now = true;
        }    

        if(collision.gameObject.tag == "Bottom")
        {
            if (Carry_Current_Score.current_score > 10)
            {
                audio_manager.Play("Decrease Score");
            }

            score_ui_manager.Decrease_Score(10);
            Destroy(this.gameObject);
        }      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Top")
        {
            audio_manager.Play("Level Up");
            StartCoroutine(Play_Transition_Effect());
           
        }
    }

    IEnumerator Play_Transition_Effect()
    {
        FindObjectOfType<Level_8_Game_Mechanics>().GetComponent<Level_8_Game_Mechanics>().start_transition = true;
        yield return new WaitForSeconds(1f);
        audio_manager.Adjust_Audio(0f, 8);
        scene_loader.Load_Next_Scene();
    }

}
