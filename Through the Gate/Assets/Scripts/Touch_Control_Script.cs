using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Control_Script : MonoBehaviour
{

    private float speed = 5;

    private float player_extents;


    private Ball ball;

    [SerializeField] float move;
    private float time = 0f;
    void Start()
    {
        player_extents = GetComponent<CapsuleCollider2D>().bounds.extents.x;

        if (Scene_Loader.scene_index != 9)          
            ball = FindObjectOfType<Ball>().GetComponent<Ball>();
        
    }


    void Update()
    {

     /*     move = Input.GetAxisRaw("Horizontal");

          if (true)
          {
              transform.position += new Vector3(move * speed * Time.deltaTime * 5, 0f, 0f);

              transform.position = new Vector2(Mathf.Clamp
                             (transform.position.x, -10 + player_extents, 10 - player_extents), transform.position.y);
          }
         else
     */
          
        if (Scene_Loader.scene_index != 9)
        {
            if (ball.game_is_started == true)
            {

                if (Input.touchCount > 0)
                {
                    time +=  Time.deltaTime;
                    for (int i = 0; i < Input.touchCount; i++)
                    {
                        if (Input.touches[i].phase == TouchPhase.Ended)
                        {
                            time = 0f;
                         
                        }
                        Vector2 touch_pos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

                        if (touch_pos.x > 0)
                        {
                            if(time <= 0.1f)
                            {
                                speed = 5f;
                            }
                            else
                            {
                                speed = 9f;
                            }
                
                            transform.position += new Vector3(1 * speed * Time.deltaTime * 5, 0f, 0f);
                               
                           
                        }
                        else if (touch_pos.x < 0)
                        {
                            if (time <= 0.1f)
                            {
                                speed = 5f;
                            }
                            else
                            {
                                speed = 9f;
                            }

                    

                            transform.position += new Vector3(-1 * speed * Time.deltaTime * 5, 0f, 0f);
                        }


                        // Restricting player movement inside screen.
                        transform.position = new Vector2(Mathf.Clamp
                            (transform.position.x, -10 + player_extents, 10 - player_extents), transform.position.y);
                    }

                }
            }

        }
        else
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Vector2 touch_pos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                    if (touch_pos.x > 0)
                    {
                        // move = Input.GetAxisRaw("Horizontal");
                        transform.position += new Vector3(1 * speed * Time.deltaTime * 5, 0f, 0f);
                    }
                    else if (touch_pos.x < 0)
                    {
                        transform.position += new Vector3(-1 * speed * Time.deltaTime * 5, 0f, 0f);
                    }


                    // Restricting player movement inside screen.
                    transform.position = new Vector2(Mathf.Clamp
                        (transform.position.x, -10 + player_extents, 10 - player_extents), transform.position.y);
                }
            }

        } 

    } 


}
