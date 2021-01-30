using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_UI_Movement : MonoBehaviour
{
    private Transform player_pos;



    private void Start()
    {  
        player_pos = FindObjectOfType<Touch_Control_Script>().GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = new Vector3(player_pos.position.x, player_pos.position.y, transform.position.z);       
    }



}
