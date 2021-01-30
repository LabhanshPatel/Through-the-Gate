/*
 * We have two enemies: "enemy_left" and "enemy_right".
 
 * "enemy_left" is following these two waypoints: "correct_waypoint_left" and "correct_waypoint_middle_enemy_left"
 * Similarly, "enemy_right" is following these two waypoints: "correct_waypoint_right" and "correct_waypoint_middle_enemy_right"
 
 * "waypoint_left", "waypoint_right", "waypoint_middle_enemy_left" and "waypoint_middle_enemy_right" are 
    used for putting values from inspector panel.

 * "current_waypoint" denotes the waypoint that enemy will follow.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement_Level_6 : MonoBehaviour
{

    [SerializeField] Transform enemy_left;
    [SerializeField] Transform enemy_right;

    [SerializeField] float waypoint_left; 
    [SerializeField] float waypoint_right;
    [SerializeField] float waypoint_middle_enemy_left;
    [SerializeField] float waypoint_middle_enemy_right;

    [SerializeField] float move_speed;

    private float correct_waypoint_left; 
    private float correct_waypoint_right;
    private float correct_waypoint_middle_enemy_left;
    private float correct_waypoint_middle_enemy_right;

    private float current_waypoint_left;
    private float current_waypoint_right;
    private float current_waypoint_middle_enemy_left;
    private float current_waypoint_middle_enemy_right;

    private float extendX;

    [SerializeField] PolygonCollider2D find_extend;


    private void Start()
    {
        extendX = find_extend.bounds.extents.x;

        correct_waypoint_left = waypoint_left + extendX;     
        correct_waypoint_right = waypoint_right - extendX;
        correct_waypoint_middle_enemy_left = waypoint_middle_enemy_left - extendX;
        correct_waypoint_middle_enemy_right = waypoint_middle_enemy_right + extendX;


        current_waypoint_left = correct_waypoint_left;
        current_waypoint_right = correct_waypoint_right;
        current_waypoint_middle_enemy_left = correct_waypoint_middle_enemy_left;
        current_waypoint_middle_enemy_right = correct_waypoint_middle_enemy_right;

    }
    void Update()
    {

     // Conditions for switching current waypoint.
        if (enemy_left.transform.position.x == correct_waypoint_left)
        {
            current_waypoint_left = correct_waypoint_middle_enemy_left;
        }
        else if(enemy_left.transform.position.x == correct_waypoint_middle_enemy_left)
        {
            current_waypoint_left = correct_waypoint_left;
        }

     // Moving enemy_left
        enemy_left.transform.position = Vector2.MoveTowards(enemy_left.transform.position,
        new Vector2(current_waypoint_left, enemy_left.transform.position.y),
        move_speed * Time.deltaTime);


                                                     // enemy_left
// **************************************************************************************************************************
                                                     // enemy_right
        
     // Conditions for switching current waypoint.
        if (enemy_right.transform.position.x == correct_waypoint_right)
        {
            current_waypoint_right = correct_waypoint_middle_enemy_right;
        }
        else if (enemy_right.transform.position.x == correct_waypoint_middle_enemy_right)
        {
            current_waypoint_right = correct_waypoint_right;
        }

     // Moving enemy_right
        enemy_right.transform.position = Vector2.MoveTowards(enemy_right.transform.position,
        new Vector2(current_waypoint_right, enemy_right.transform.position.y),
        move_speed * Time.deltaTime);

    }

}
