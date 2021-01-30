using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_10_Game_Mechanics : MonoBehaviour
{
    [SerializeField] Transform top_left;
    [SerializeField] Transform top_right;


    public bool hit_detected_level10 = false;


    float waypoint_top_left;
    float waypoint_top_right;

    bool allow_first_time = true;

    [SerializeField] float move_speed;

    [SerializeField] float shift_distance;

    void Update()
    {


        if (hit_detected_level10)
        {
            if ((top_left.position.x <= (waypoint_top_left + 0.01) && top_left.position.x >= (waypoint_top_left - 0.01))
                || (allow_first_time == true))
            {
                waypoint_top_left = top_left.transform.position.x - shift_distance;
                waypoint_top_right = top_right.transform.position.x + shift_distance;

                allow_first_time = false;
            }


            top_left.transform.position = Vector2.MoveTowards(top_left.transform.position,
            new Vector2(waypoint_top_left, top_left.transform.position.y),
            move_speed * Time.deltaTime);


            top_right.transform.position = Vector2.MoveTowards(top_right.transform.position,
            new Vector2(waypoint_top_right, top_right.transform.position.y),
            move_speed * Time.deltaTime);


            if (top_left.position.x <= (waypoint_top_left + 0.01) && top_left.position.x >= (waypoint_top_left - 0.01))
            {
                hit_detected_level10 = false;
            }

        }
    }
}
