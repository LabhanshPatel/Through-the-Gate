using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry_Current_Score : MonoBehaviour
{
    public static int current_score = 0;

    void Awake()
    {
        if (FindObjectsOfType<Carry_Current_Score>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }


}
