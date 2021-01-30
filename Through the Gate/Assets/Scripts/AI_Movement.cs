using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    [SerializeField] Transform Ball_pos;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float move_speed;
    private float AI_extents;

    private Audio_Manager audio_manager;

    void Start()
    {
        AI_extents = GetComponent<CapsuleCollider2D>().bounds.extents.x;

        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
    }
    void Update()
    {
        if (this.gameObject.name != "A.I. Easy")
        {
            if (Ball_pos.position.y > 0 && rb.velocity.y > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Ball_pos.position.x,
                    transform.position.y, transform.position.z), move_speed * Time.deltaTime);
            }
        }
        else
        {
            if (Ball_pos.position.y < 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Ball_pos.position.x,
                    transform.position.y, transform.position.z), move_speed * Time.deltaTime);
            }
        }

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -10 + AI_extents, 10 - AI_extents), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.name == "A.I. Easy")
        {
            audio_manager.Play("A.I. 2");
        }
        else
        {
            audio_manager.Play("A.I.");
        }
    }

    
}
