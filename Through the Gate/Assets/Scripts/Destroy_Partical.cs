using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Partical : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(Destroy_Object());
    }

    IEnumerator Destroy_Object()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
