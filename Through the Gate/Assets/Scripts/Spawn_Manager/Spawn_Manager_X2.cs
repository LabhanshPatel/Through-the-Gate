using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**************************************Check Spawn_MAnager_X1 script for Comments*********************************************************
public class Spawn_Manager_X2 : MonoBehaviour
{
    [SerializeField] float Yposition;

    private float randomX2;
    private float extendX;

    private bool result;
    private bool can_spawn;
    private bool is_started = true;
    private bool max_limit = false;
    private bool flag = true;

    public int count_blocks_X2;

    [SerializeField] Collider2D[] detected_blocks;
    [SerializeField] GameObject block_prefab;


  
    private void Update()
    {
        if (is_started)
        {
            StartCoroutine(Block_Spawner());
            is_started = false;

        }

        if (max_limit && count_blocks_X2 < 5)
        {
            is_started = true;
            max_limit = false;
        }
    }

    IEnumerator Block_Spawner()
    {
        while (true)
        {
            randomX2 = Random.Range(-8.5f, 8.5f);
            
            
            can_spawn = Check_Spawn_X2(randomX2);

            if (can_spawn && count_blocks_X2 < 5)
            {
                yield return new WaitForSeconds(1f);
              
                Instantiate(block_prefab, new Vector2(randomX2, Yposition), Quaternion.identity);
                count_blocks_X2++;

                if (flag)
                {

                    extendX = FindObjectOfType<Block>().GetComponent<BoxCollider2D>().bounds.extents.x;
                    flag = false;
                }

                yield return new WaitForSeconds(Random.Range(5f, 20f));// 20,30

            }

            if (count_blocks_X2 >= 5)
            {
                max_limit = true;
                break;
            }
        }
    }


    bool Check_Spawn_X2(float RandomX2)
    {
        result = true;

        if (Scene_Loader.scene_index == 1 || Scene_Loader.scene_index == 2 || Scene_Loader.scene_index == 3
            || Scene_Loader.scene_index == 6 || Scene_Loader.scene_index == 10)
            detected_blocks = Physics2D.OverlapAreaAll(new Vector2(-10f, 9.5f), new Vector2(10f, 8.5f));
        else if (Scene_Loader.scene_index == 5)
            detected_blocks = Physics2D.OverlapAreaAll(new Vector2(-10f, 5.5f), new Vector2(10f, 4.5f));

        for (int i = 0; i < detected_blocks.Length; i++)
        {
            Vector2 centre_pos = detected_blocks[i].bounds.center;          

            if (RandomX2 < centre_pos.x - (2 * extendX + 0.3f) || RandomX2 > centre_pos.x + (2 * extendX + 0.3f))
            {
                result = true;
            }
            else
            {
                result = false;
                break;
            }

        }
        return result;
    }

}
