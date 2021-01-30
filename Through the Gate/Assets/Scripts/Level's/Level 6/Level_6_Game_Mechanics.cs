using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_6_Game_Mechanics : MonoBehaviour
{
    [SerializeField] GameObject bottom_left_barrier;
    [SerializeField] GameObject bottom_right_barrier;

    public bool hit_detected_level6 = false;

    [SerializeField] float shift_distance;
    [SerializeField] float move_speed;

    float waypoint_bottom_left;
    float waypoint_bottom_right;

    bool allow_first_time = true;



    void Update()
    {
        if (hit_detected_level6)
        {
            if ((bottom_left_barrier.transform.position.x == waypoint_bottom_left) || (allow_first_time == true))
            {
                waypoint_bottom_left = bottom_left_barrier.transform.position.x - shift_distance;
                waypoint_bottom_right = bottom_right_barrier.transform.position.x + shift_distance;

                allow_first_time = false;
            }

            bottom_left_barrier.transform.position = Vector2.MoveTowards(bottom_left_barrier.transform.position,
              new Vector2(waypoint_bottom_left, bottom_left_barrier.transform.position.y),
              move_speed * Time.deltaTime);


            bottom_right_barrier.transform.position = Vector2.MoveTowards(bottom_right_barrier.transform.position,
            new Vector2(waypoint_bottom_right, bottom_right_barrier.transform.position.y),
            move_speed * Time.deltaTime);

            if (bottom_left_barrier.transform.position.x == waypoint_bottom_left)
            {
                hit_detected_level6 = false;
            }
        }
    }
}
