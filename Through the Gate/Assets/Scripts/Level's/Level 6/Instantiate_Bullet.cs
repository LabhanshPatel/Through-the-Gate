using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Bullet : MonoBehaviour
{
    [SerializeField] Transform spawn_pos;
    [SerializeField] GameObject bullet_prefab;
    [SerializeField] float bullet_speed;

    private Audio_Manager audio_manager;

    void Start()
    {
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();

        StartCoroutine(Spawn_Bullets());
    }

    IEnumerator Spawn_Bullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            var bullet_instance = Instantiate(bullet_prefab, spawn_pos.position, Quaternion.identity) as GameObject;

            bullet_instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -1000 * bullet_speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio_manager.Play("A.I.");
    }
}
