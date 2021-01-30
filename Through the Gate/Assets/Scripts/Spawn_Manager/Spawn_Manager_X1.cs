using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager_X1 : MonoBehaviour
{
 // Yposition is position of block on y axis
    [SerializeField] float Yposition;

 // randomX1 is a random value within screenbounds at Yposition.
    private float randomX1;   
    private float extendX;

    private bool result;
    private bool can_spawn;
    private bool start_coroutine = true;
    private bool max_limit = false;
    private bool flag = true;

 // Blocks detected inside the Physics2D.OverLapAreaAll.
    [SerializeField] Collider2D[] detected_blocks;
    [SerializeField] GameObject block_prefab;
   
    public int count_blocks_X1;


    
    private void Update()
    {
        
        if (start_coroutine)
        {
            StartCoroutine(Block_Spawner());
            start_coroutine = false;          
        }

        if( (max_limit==true) && (count_blocks_X1 < 5) )
        {
            start_coroutine = true;

         /* We don't want our Block_Spawner coroutine to start again and again in void update().
            That's why we created max_limit bool which indicates that only start coroutine again when max limit has been reached! */ 
            max_limit = false;
        }
    }


    IEnumerator Block_Spawner()
    {
       
        while (true)
        {
            randomX1 = Random.Range(-8.5f, 8.5f);           
           
           
            can_spawn = Check_Spawn_X1(randomX1);

            if ( (can_spawn==true) && (count_blocks_X1 < 5) )
            {
                yield return new WaitForSeconds(1f);
               
                Instantiate(block_prefab, new Vector2(randomX1, Yposition), Quaternion.identity);
                count_blocks_X1++;

                if (flag)
                {
                    extendX = FindObjectOfType<Block>().GetComponent<BoxCollider2D>().bounds.extents.x;
                    flag = false;
                }
                yield return new WaitForSeconds(Random.Range(5f, 20f));// 25,50

            }

            if (count_blocks_X1 >= 5)
            {
             // since, total no. of blocks are 5 now, so the max limit has reached.  
                max_limit = true;
             // getting out of the coroutine.  
                break;
            }
        }
    }


    private bool Check_Spawn_X1(float RandomX1)
    {
        result = true;

        /*  This one is the most imp!!!. Here, detected_blocks is an array of type Collider2D.
            And we are assigning all the colliders that lie inside the area covered by Physics2D.OverLapAreaAll
            to the detected_blocks array.*/

        if (Scene_Loader.scene_index == 1 || Scene_Loader.scene_index == 2 || Scene_Loader.scene_index == 3
            || Scene_Loader.scene_index == 6 || Scene_Loader.scene_index == 10)
            detected_blocks = Physics2D.OverlapAreaAll(new Vector2(-10f, 11.5f), new Vector2(10f, 10.5f));
        else if (Scene_Loader.scene_index == 5)
            detected_blocks = Physics2D.OverlapAreaAll(new Vector2(-10f, 10.5f), new Vector2(10f, 9.5f));
        else if (Scene_Loader.scene_index == 9)                
           detected_blocks = Physics2D.OverlapAreaAll(new Vector2(-10f, 15.5f), new Vector2(10f, 12.5f));
        
        //  Now, since we have all colliders stored inside our detected_blocks array, we can iterate through each one of them. 
        for (int i = 0; i < detected_blocks.Length; i++)
        {
            Vector2 centre_pos = detected_blocks[i].bounds.center;
            
          
         // Checking weather RandomX1 lies inside any existing bloack or not and returning the final result.
            if (RandomX1 < (centre_pos.x - (2 * extendX +0.3f)) || RandomX1 > (centre_pos.x + (2 * extendX + 0.3f)))
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
