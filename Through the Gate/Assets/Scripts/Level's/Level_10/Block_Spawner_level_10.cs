using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Block_Spawner_level_10 : MonoBehaviour
{
    [SerializeField] GameObject block_prefab;
    private Level_10_Game_Mechanics level_10_game_mechanics;


    private bool flag;
    void Start()
    {
        level_10_game_mechanics = FindObjectOfType<Level_10_Game_Mechanics>();
        flag = true;
    }

    private void Update()
    {
        if(flag == true && level_10_game_mechanics.hit_detected_level10 == true)
        {
           
            StartCoroutine(Spawn_Block());
            flag = false;
        }
    }
    IEnumerator Spawn_Block()
    {       
        yield return new WaitForSeconds(3f);
    
        Instantiate(block_prefab, new Vector2(0f, 16f), Quaternion.identity);

        flag = true;
    }
   
}
