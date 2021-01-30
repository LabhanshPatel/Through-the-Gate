using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open_Tutorial_First : MonoBehaviour
{
    private const string key_name = "Show_Tutorial";

    void Start()
    {
        if (PlayerPrefs.HasKey(key_name) == false)
        { 
            
            Load_Tutorial();
        }            
    }

    public void Load_Tutorial()
    {
        SceneManager.LoadScene(21);
    }
    
}
