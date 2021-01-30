using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Level_9_Game_Mechanics : MonoBehaviour
{
    [SerializeField] Transform bottom_left;
    [SerializeField] Transform bottom_right;


    [SerializeField] float move_speed;

    private bool move_barriers_backward = false;
    private bool move_barriers_forward = false;


    private void Start()
    {
        StartCoroutine(Move_Mechanics());
    }

    private void Update()
    {
        if (move_barriers_backward)
        {
            Move_Barriers_Backward();
   
        }
        else if (move_barriers_forward)
        {
            Move_Barriers_Forward();
    
        }
    }

    IEnumerator Move_Mechanics()
    {
        while (true)
        {

            move_barriers_forward = false;

            yield return new WaitForSeconds(12f);

            move_barriers_backward = true;

            yield return new WaitForSeconds(3f);

            move_barriers_backward = false;
            move_barriers_forward = true;

            yield return new WaitForSeconds(1f);
             
        }
    }

    void Move_Barriers_Backward()
    {
        bottom_left.position = Vector2.MoveTowards(bottom_left.position, new Vector2(-15.5f, bottom_left.position.y), move_speed * Time.deltaTime);
        bottom_right.position = Vector2.MoveTowards(bottom_right.position, new Vector2(15.5f, bottom_right.position.y), move_speed * Time.deltaTime);
    }

    void Move_Barriers_Forward()
    {
        bottom_left.position = Vector2.MoveTowards(bottom_left.position, new Vector2( -5f, bottom_left.position.y), move_speed * Time.deltaTime * 12);
        bottom_right.position = Vector2.MoveTowards(bottom_right.position, new Vector2( 5f, bottom_right.position.y), move_speed * Time.deltaTime * 12);
    }

}
