using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball_Spawner : MonoBehaviour
{
    [SerializeField] GameObject ball_prefab;
    [SerializeField] Transform left_spawn_pos;
    [SerializeField] Transform right_spawn_pos;

    [SerializeField] float spawn_time;


    private float forceY;

    private Audio_Manager audio_manager;
    void Start()
    {
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
        StartCoroutine(Spawn_Ball()); 
    }

   IEnumerator Spawn_Ball()
    {
        while (true)
        {
            forceY = UnityEngine.Random.Range(1000f,5000f);
            yield return new WaitForSeconds(spawn_time);
            if (this.gameObject.name == "Barrel Left")
            {
                var ball_instance = Instantiate(ball_prefab, left_spawn_pos.position, Quaternion.identity) as GameObject;
                ball_instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceY * 1.428f, forceY)); // here "1.428" is cot(57.2 degree's).
                audio_manager.Play("Falling Ball");
            }
            else if (this.gameObject.name == "Barrel Right")
            {
                var ball_instance = Instantiate(ball_prefab, right_spawn_pos.position, Quaternion.identity) as GameObject;
                ball_instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-forceY * 0.644f, forceY)); // here "0.644" is cot(35 degree's).
                audio_manager.Play("Falling Ball");

            }
        }
    }
}
