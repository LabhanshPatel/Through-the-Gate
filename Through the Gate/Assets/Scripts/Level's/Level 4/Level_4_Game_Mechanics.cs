using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_Game_Mechanics : MonoBehaviour
{
    [SerializeField] float rotation_speed;

    [SerializeField] Transform wheel_A;
    [SerializeField] Transform wheel_B;
    [SerializeField] Transform wheel_C;
    [SerializeField] Transform wheel_D;


    [SerializeField] Transform top_left;
    [SerializeField] Transform top_right;

    public bool hit_detected_level4 = false;


    float waypoint_top_left;
    float waypoint_top_right;

    bool allow_first_time = true;

    [SerializeField] float move_speed;

    [SerializeField] float shift_distance;


    
    void Update()
    {
        wheel_A.Rotate(new Vector3(0f, 0f, -rotation_speed* Time.deltaTime)); // clockwise
        wheel_B.Rotate(new Vector3(0f, 0f, -rotation_speed* Time.deltaTime)); // anti-clockwise

        wheel_C.Rotate(new Vector3(0f, 0f, -rotation_speed* Time.deltaTime)); // anti-clockwise
        wheel_D.Rotate(new Vector3(0f, 0f, -rotation_speed* Time.deltaTime)); // clockwise

        if (hit_detected_level4)
        {
            if ((top_left.transform.position.x == waypoint_top_left) || (allow_first_time == true))
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


            if (top_left.transform.position.x == waypoint_top_left)
            {
                hit_detected_level4 = false;
            }

        }
    }

  


}
