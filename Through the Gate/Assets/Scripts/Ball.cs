using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static int Lifes = 3;
    public bool game_is_started = false;



    [SerializeField] float launch_velocity;

    private Transform player_pos;
    private Rigidbody2D rb_ball;
    private Score_UI_Manager score_manager;
    private Scene_Loader scene_loader;

    private Audio_Manager audio_manager;

 
    private Vector2 player_to_ball_vector;

    [SerializeField] Animator scene_transition;
   

    void Start()
    {

     // taking references.
        scene_loader = FindObjectOfType<Scene_Loader>();
        rb_ball = GetComponent<Rigidbody2D>();
        player_pos = FindObjectOfType<Touch_Control_Script>().transform;
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
        


        if (Scene_Loader.scene_index != 15 && Scene_Loader.scene_index != 16 && Scene_Loader.scene_index != 17 && Scene_Loader.scene_index != 21)
        {
            score_manager = GameObject.Find("Score_UI_Manager").GetComponent<Score_UI_Manager>();
        }

     // ball_to_player_vector helps in attaching the ball with the paddle before launching it.
        player_to_ball_vector = transform.position - player_pos.position;
 
    }

    
    void Update()
    {
        Launch_The_Ball();

        Speed_Controlling();

    }

    private void Speed_Controlling()
    {
        if (Scene_Loader.scene_index == 1 || Scene_Loader.scene_index == 2 || Scene_Loader.scene_index == 3
            || Scene_Loader.scene_index == 6 || Scene_Loader.scene_index == 10)
            
        {
            if (Mathf.Abs(rb_ball.velocity.y) > 25)
            {

                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, -5f);
                else
                    rb_ball.velocity += new Vector2(0, 5f);
                
            }

           
            if (Mathf.Abs(rb_ball.velocity.y) < 10f)
            {
                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, 5f);
                else
                    rb_ball.velocity += new Vector2(0, -5f);
            }

        }
        else if (Scene_Loader.scene_index == 4)
        {

            if (Mathf.Abs(rb_ball.velocity.y) > 20f)
            {

                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, -5f);
                else
                    rb_ball.velocity += new Vector2(0, 5f);
            }

            if (Mathf.Abs(rb_ball.velocity.y) < 8f)
            {
                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, 5f);
                else
                    rb_ball.velocity += new Vector2(0, -5f);
            }
        }
        else if(Scene_Loader.scene_index == 5)
        {

            if (Mathf.Abs(rb_ball.velocity.y) > 35)
            {

                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, -5f);
                else
                    rb_ball.velocity += new Vector2(0, 5f);
            }

            if (Mathf.Abs(rb_ball.velocity.y) < 15f)
            {
                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, 5f);
                else
                    rb_ball.velocity += new Vector2(0, -5f);
            }
        }
        else if (Scene_Loader.scene_index == 7)
        {

            if (Mathf.Abs(rb_ball.velocity.y) > 20)
            {

                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, -5f);
                else
                    rb_ball.velocity += new Vector2(0, 5f);
            }


            if (Mathf.Abs(rb_ball.velocity.y) < 5f)
            {
                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0,5f);
                else
                    rb_ball.velocity += new Vector2(0, -5f);
            }

        }
        else if (Scene_Loader.scene_index == 11)
        {

            if (Mathf.Abs(rb_ball.velocity.y) > 30)
            {

                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, -10f);
                else
                    rb_ball.velocity += new Vector2(0, 10f);
            }

            if (Mathf.Abs(rb_ball.velocity.y) < 10f)
            {
                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, 10f);
                else
                    rb_ball.velocity += new Vector2(0, -10f);
            }
        }
        else if (Scene_Loader.scene_index == 15 || Scene_Loader.scene_index == 16)
        {

            if (Mathf.Abs(rb_ball.velocity.y) > 35)
            {

                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, -10f);
                else
                    rb_ball.velocity += new Vector2(0, 10f);
            }

            if (Mathf.Abs(rb_ball.velocity.y) < 10f)
            {
                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, 5f);
                else
                    rb_ball.velocity += new Vector2(0, -5f);
            }
        }
        else if (Scene_Loader.scene_index == 17)
        {

            if (Mathf.Abs(rb_ball.velocity.y) > 40)
            {

                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, -5f);
                else
                    rb_ball.velocity += new Vector2(0, 5f);
            }

            if (Mathf.Abs(rb_ball.velocity.y) < 10f)
            {
                if (rb_ball.velocity.y > 0)
                    rb_ball.velocity += new Vector2(0, 10f);
                else
                    rb_ball.velocity += new Vector2(0, -10f);
            }
        }

    }

    private void Launch_The_Ball()
    {
        if (!game_is_started)
        {
         // when the game is not started, we want ball to stay at the centre of the paddle 
            transform.position = (Vector2)player_pos.position + player_to_ball_vector;

            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    
                    rb_ball.velocity = new Vector2(2f, launch_velocity);
                    game_is_started = true;
                }
            }  

        /*    if (Input.GetKeyDown(KeyCode.Space))
            {
               

                    rb_ball.velocity = new Vector2(2f, launch_velocity);
                    game_is_started = true;
                
            } */
         
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (game_is_started == true)
            {
                audio_manager.Play("Player");
            }
        }

        if (collision.gameObject.tag == "Block_Bottom")
        {
          //find better place for this line of code(if you can)
           // scene_transition.SetBool("level_start", false);


            if (Block.block_has_been_destroyed)
            {
                score_manager.Increase_Score(10);
            
                Block.block_has_been_destroyed = false;

            }
        }

        // Giving some randomness to the Ball Direction on collision.
        Apply_Random_Friction();

        if (collision.gameObject.tag == "Player")
        {
            rb_ball.velocity = new Vector2((transform.position.x - player_pos.position.x) * 500f * Time.deltaTime, rb_ball.velocity.y);
        }

        if (collision.gameObject.tag == "Bottom")
        {
           
            if(Lifes > 1)
            {
                GameObject.Find("Life's").transform.Find("Canvas").transform.Find(Lifes.ToString()).gameObject.SetActive(false);
                Lifes--;

                if(Lifes == 1)
                {
                   GameObject.Find("Play_Space").transform.Find("Bottom").GetComponent<BoxCollider2D>().isTrigger = true;
                }
            }
        }

    }

    private void Apply_Random_Friction()
    {
        rb_ball.velocity += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));            
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Top")
        {
            if (Scene_Loader.scene_index != 15 && Scene_Loader.scene_index != 16 && Scene_Loader.scene_index != 17)
            {
                StartCoroutine(Start_Scene_Transitioning_1());
            }
            else
            {
                StartCoroutine(Start_Scene_Transitioning_2());

            }

        }

        if (collision.gameObject.tag == "Bottom")
        {
            if (Lifes > 1)
            {
                GameObject.Find("Life's").transform.Find("Canvas").transform.Find(Lifes.ToString()).gameObject.SetActive(false);
                Lifes--;

                StartCoroutine(Reload_Scene());
            }
            else if (Lifes == 1)
            {
                audio_manager.Play("Game Over");
                scene_loader.Load_Game_Over_Scene();
                GameObject.Find("Life's").transform.Find("Canvas").transform.Find(Lifes.ToString()).gameObject.SetActive(false);
            }
        }
    }

    IEnumerator Start_Scene_Transitioning_1()
    {
        audio_manager.Play("Level Up");

        if (Scene_Loader.scene_index != 7)
        {
            scene_transition.SetBool("level_over", true);           
        }
        else
        {         
            scene_transition.SetBool("end_transition", true);
        }
   

        yield return new WaitForSeconds(1f);

        scene_loader.Load_Next_Scene();

    }

    IEnumerator Start_Scene_Transitioning_2()
    {
        if (Scene_Loader.scene_index == 15)
        {
            Carry_Current_Score.current_score += 50;
        }
        else if (Scene_Loader.scene_index == 16)
        {
            Carry_Current_Score.current_score += 100;
        }
        else if (Scene_Loader.scene_index == 17)
        {
            Carry_Current_Score.current_score += 200;
        }


        scene_transition.SetBool("end_transition", true);

        yield return new WaitForSeconds(1f);


        // each level will direct to 8th level.
        scene_loader.Load_Scene_By_Index(9);
    }

    IEnumerator Reload_Scene()
    {
        audio_manager.Play("Life loss");
           
        yield return new WaitForSeconds(1f);
        
        scene_loader.Load_Current_Scene();
    }
}
