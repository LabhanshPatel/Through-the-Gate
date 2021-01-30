using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
  

    private Audio_Manager audio_manager;
    void Start()
    {
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player collide with bullet then score will be reduced.
        if (collision.gameObject.tag == "Player")
        {
           
            if (Carry_Current_Score.current_score > 10)
            {
                audio_manager.Play("Decrease Score");
            }

            FindObjectOfType<Score_UI_Manager>().GetComponent<Score_UI_Manager>().Decrease_Score(5);
        }

        if(collision.gameObject.tag != "Ball")
            Destroy(this.gameObject);
    }
}
