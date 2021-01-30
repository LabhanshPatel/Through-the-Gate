using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if(FindObjectsOfType<Lifes_Manager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    
    

}
