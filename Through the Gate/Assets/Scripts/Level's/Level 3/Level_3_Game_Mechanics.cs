/* This one is a little bit complicated. Let me explain it.
 
 * In total there are 20 "tile_objects"(or barriers). We will devide them into 5 groups each containing 4 barriers
   group 1: (1,2,3,4) group 2: (5,6,7,8) group 3: (9,10,11,12) group 4: (13,14,15,16) group 5: (17,18,19,20) //check in hierarchy.
   
 * We will loop through each group to move them towerds the waypoints.
   (some variables are created for looping purpose, don't mind them!!! They are doing their job pretty well.
    i.e.: count1, count2, a, waypoint_index, change_direction)
   
 * By moving each group at different timing, we can achieve beautiful and meaningful petterns.
   so for that, we need to keep track of timings. To we have created 2 timers: step1 and step2 (Let's check these two steps)
   
 * The whole mechanics is devided into two steps:
   1. Opening the barriers (timer name: "time") // step1
   2. Closing the barriers (timer name: "time_reverse") // step2      */

using UnityEngine;

public class Level_3_Game_Mechanics : MonoBehaviour
{
    [SerializeField] GameObject[] tile_object;
    [SerializeField] float[] waypoints;

    [SerializeField] float move_speed;
    [SerializeField] float move_speed_reverse;

 // This public variable got referenced in "Block" script and changes its value to true when ball hit the block.
    [HideInInspector] public bool hit_detected_level3;

 // This public bool prevents whole movement from restaring again before it has completed. Whole mechanics take 4.2f sec to complete. 
    [HideInInspector] public bool can_do_move_mechanics = true;

    private bool start_reverse = false;

 // Timers
    private float time = 0f;
    private float time_reverse = 0f;
 
 // Loop variables
    private int count2;
    private int count1;
    private int waypoint_index =0;
    private int change_direction =1;

    private void Update()
    {
        // Step 1     
        if (hit_detected_level3)
        {
            can_do_move_mechanics = false;

            time += Time.deltaTime;

         // resetting time_reverse to zero
            time_reverse = 0;

            Move_Mechanics();

        }

        // Step 2
        if (start_reverse)
        {
         /* Note:
            This action(below) can not be done in step 1 because hit_detected_Level3 needs to remain true until step 2 begins.
            Becaue Vector2.MoveTowards do not works in one frame i.e. it moves the object to its destination frame by frame.
            It's a basic problems with moving objects using transform rather then using Physics on them (Rigidbody2D) */
            hit_detected_level3 = false;

            time_reverse += Time.deltaTime;

            // resetting time_reverse to zero
            time = 0;

            Reverse_Move_Mechanics();

        }
    }


    private void Move_Mechanics()
    {
        count1 = 0;
        waypoint_index = 0;
       
        Moving_System();

     // Moving different groups at defferent timing.  
        if (time > 0.4f)
            Moving_System();
        if (time > 0.8f)
            Moving_System();
        if (time > 1.2f)
            Moving_System();
        if (time > 1.6f)
            Moving_System();
        if (time > 5)
        {
         // Step two begins!!!
            start_reverse = true;
        }
    }

    void Moving_System()
    {
        int a = -1;
        int i = count1;
    
     // Moving all 4 members of each group towards their respective waypoints.    
        for ( ; count1 < i+4; count1++)
        {           
            tile_object[count1].transform.position = Vector2.MoveTowards(tile_object[count1].transform.position,
            new Vector2(a *change_direction* waypoints[waypoint_index], tile_object[count1].transform.position.y),
            move_speed * Time.deltaTime);

            a *= -1;
        }
        waypoint_index++;
    }



    private void Reverse_Move_Mechanics()
    {
        count2 = 19;

     // Moving different groups at defferent timing.  
        if (time_reverse > 3f)
            Reverse_Moving_System();
        if (time_reverse > 3.5f)
            Reverse_Moving_System();
        if (time_reverse > 3.4f)
            Reverse_Moving_System();
        if (time_reverse > 3.3f)
            Reverse_Moving_System();
        if (time_reverse > 3.2f)
            Reverse_Moving_System();

        if (time_reverse > 4.4f)//4.4f
        {
            change_direction *= -1;
            can_do_move_mechanics = true;
            start_reverse = false;
        }

        // End of whole mechanics.
    }



    private void Reverse_Moving_System()
    {
        int i = count2;
        int a = -1;

        // Moving all 4 members of each group towards their respective waypoints.    
        for (; count2 > i - 4; count2--)
        {
            tile_object[count2].transform.position = Vector2.MoveTowards(tile_object[count2].transform.position,
            new Vector2(a * change_direction * 5f, tile_object[count2].transform.position.y),
            move_speed_reverse * Time.deltaTime);

            a *= -1;
        }
    }

}
