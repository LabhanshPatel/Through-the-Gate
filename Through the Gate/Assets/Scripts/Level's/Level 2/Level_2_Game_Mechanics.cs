using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_2_Game_Mechanics : MonoBehaviour
{


    [SerializeField] GameObject A1;
    [SerializeField] GameObject A2;
    [SerializeField] GameObject B1;
    [SerializeField] GameObject B2;
    [SerializeField] GameObject C1;         
    [SerializeField] GameObject C2;
    [SerializeField] GameObject D1;
    [SerializeField] GameObject D2;

 // This public variable got referenced in "Block" script and changes its value to true when ball hit the block.
    public bool hit_detected_level2_top = false;
    public bool hit_detected_level2_bottom = false;

    [SerializeField] float shift_distance_top = 15f;
    [SerializeField] float shift_distance_bottom = 15f;

    [SerializeField] float move_speed;

    float waypoint_A1;
    float waypoint_A2;
    float waypoint_B1;
    float waypoint_B2;
    float waypoint_C1;
    float waypoint_C2;
    float waypoint_D1;
    float waypoint_D2;

    bool allow_first_time_top = true;
    bool allow_first_time_bottom = true;

    bool check_first_time_top = true;
    bool check_first_time_bottom = true;


    void Update()
    {
      

        if (hit_detected_level2_top)
        {
            if (B1.transform.position.x >= -15.5f)
            {
                if ((B1.transform.position.x == waypoint_B1) || allow_first_time_top)
                {                 
                    waypoint_B1 = B1.transform.position.x - shift_distance_top;
                    waypoint_B2 = B2.transform.position.x + shift_distance_top;
                                
                    allow_first_time_top = false;
                }

          
                B1.transform.position = Vector2.MoveTowards(B1.transform.position,
                new Vector2(waypoint_B1, B1.transform.position.y),
                move_speed * Time.deltaTime);


                B2.transform.position = Vector2.MoveTowards(B2.transform.position,
                new Vector2(waypoint_B2, B2.transform.position.y),
                move_speed * Time.deltaTime);
                      

                if (B1.transform.position.x == waypoint_B1)
                {
                    hit_detected_level2_top = false;
                }
            }
            else
            {
                if(check_first_time_top)
                {
                    allow_first_time_top = true;
                    check_first_time_top = false;
                }

                if ((A1.transform.position.x == waypoint_A1) || allow_first_time_top)
                {
                    waypoint_A1 = A1.transform.position.x - shift_distance_top;
                    waypoint_A2 = A2.transform.position.x + shift_distance_top;                                  

                    allow_first_time_top = false;
                }



                A1.transform.position = Vector2.MoveTowards(A1.transform.position,
                new Vector2(waypoint_A1, A1.transform.position.y),
                move_speed * Time.deltaTime);

                A2.transform.position = Vector2.MoveTowards(A2.transform.position,
                new Vector2(waypoint_A2, A2.transform.position.y),
                move_speed * Time.deltaTime);


                if (A1.transform.position.x == waypoint_A1)
                {
                    hit_detected_level2_top = false;
                }

            }
        }

        if(hit_detected_level2_bottom)
        {
            if (C1.transform.position.x >= -15.5f)
            {
                if ((C1.transform.position.x == waypoint_C1) || allow_first_time_bottom)
                {
                    waypoint_C1 = C1.transform.position.x - shift_distance_bottom;
                    waypoint_C2 = C2.transform.position.x + shift_distance_bottom;

                    allow_first_time_bottom = false;
                }
              
                C1.transform.position = Vector2.MoveTowards(C1.transform.position,
                new Vector2(waypoint_C1, C1.transform.position.y),
                move_speed * Time.deltaTime);


                C2.transform.position = Vector2.MoveTowards(C2.transform.position,
                new Vector2(waypoint_C2, C2.transform.position.y),
                move_speed * Time.deltaTime);



                if (C1.transform.position.x == waypoint_C1)
                {
                    hit_detected_level2_bottom = false;
                }
            }
            else
            {
                if (check_first_time_bottom)
                {
                    allow_first_time_bottom = true;
                    check_first_time_bottom = false;
                }

                if ((D1.transform.position.x == waypoint_D1) || allow_first_time_bottom)
                {
                
                    waypoint_D1 = D1.transform.position.x - shift_distance_top;
                    waypoint_D2 = D2.transform.position.x + shift_distance_top;

                    allow_first_time_bottom = false;
                }

                D1.transform.position = Vector2.MoveTowards(D1.transform.position,
                new Vector2(waypoint_D1, D1.transform.position.y),
                move_speed * Time.deltaTime);

                D2.transform.position = Vector2.MoveTowards(D2.transform.position,
                new Vector2(waypoint_D2, D2.transform.position.y),
                move_speed * Time.deltaTime);

                if (D1.transform.position.x == waypoint_D1)
                {
                    hit_detected_level2_bottom = false;
                }

            }

        }
        
    }
}
