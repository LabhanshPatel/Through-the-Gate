using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Game_Mechanics : MonoBehaviour
{

    [SerializeField] GameObject top_left_barrier;
    [SerializeField] GameObject top_right_barrier;
    [SerializeField] GameObject bottom_left_barrier;
    [SerializeField] GameObject bottom_right_barrier;

 // This two public variables will get referenced by "Block" script and changes its value to true when ball hit the block.
    public bool hit_detected_level1_top = false;
    public bool hit_detected_level1_bottom = false;
  

    [SerializeField] float shift_distance_top;
    [SerializeField] float shift_distance_bottom;


    [SerializeField] float move_speed;

    float waypoint_top_left;
    float waypoint_top_right;
    float waypoint_bottom_left;
    float waypoint_bottom_right;

    bool allow_first_time_top = true;
    bool allow_first_time_bottom = true;



    void Update()
    {
       
      // For moving top positioned barriers
        if(hit_detected_level1_top)
        {
            Move_Top_Barriers();
        }

        // For moving bottom positioned barriers
        if (hit_detected_level1_bottom)
        {
            Move_Bottom_Barriers();
        }
    }

    private void Move_Top_Barriers()
    {
        /* When barrier's has reached our waypoints, we want to shift the waypoints again 
           so that barrier's will continue to move towards them. */
        if ((top_left_barrier.transform.position.x == waypoint_top_left) || (allow_first_time_top == true))
        {
            waypoint_top_left = top_left_barrier.transform.position.x - shift_distance_top;
            waypoint_top_right = top_right_barrier.transform.position.x + shift_distance_top;

            allow_first_time_top = false;
        }


        top_left_barrier.transform.position = Vector2.MoveTowards(top_left_barrier.transform.position,
        new Vector2(waypoint_top_left, top_left_barrier.transform.position.y),
        move_speed * Time.deltaTime);


        top_right_barrier.transform.position = Vector2.MoveTowards(top_right_barrier.transform.position,
        new Vector2(waypoint_top_right, top_right_barrier.transform.position.y),
        move_speed * Time.deltaTime);


        if (top_left_barrier.transform.position.x == waypoint_top_left)
        {
            hit_detected_level1_top = false;
        }
    }
    private void Move_Bottom_Barriers()
    {
        if ((bottom_left_barrier.transform.position.x == waypoint_bottom_left) || (allow_first_time_bottom == true))
        {
            waypoint_bottom_left = bottom_left_barrier.transform.position.x - shift_distance_bottom;
            waypoint_bottom_right = bottom_right_barrier.transform.position.x + shift_distance_bottom;

            allow_first_time_bottom = false;
        }

        bottom_left_barrier.transform.position = Vector2.MoveTowards(bottom_left_barrier.transform.position,
          new Vector2(waypoint_bottom_left, bottom_left_barrier.transform.position.y),
          move_speed * Time.deltaTime);


        bottom_right_barrier.transform.position = Vector2.MoveTowards(bottom_right_barrier.transform.position,
        new Vector2(waypoint_bottom_right, bottom_right_barrier.transform.position.y),
        move_speed * Time.deltaTime);

        if (bottom_left_barrier.transform.position.x == waypoint_bottom_left)
        {
            hit_detected_level1_bottom = false;
        }
    }

   
}
