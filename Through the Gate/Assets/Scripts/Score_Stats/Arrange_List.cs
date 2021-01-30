using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrange_List : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] score_text;

    int[] score_pos = new int[10];


    private int highest_score;

 
    void Start()
    {
       //  reset score to zero here:
       // PlayerPrefs.SetInt("Highest_Score", 0);

        highest_score = PlayerPrefs.GetInt("Highest_Score");

        score_pos[0] = 1000;
        score_pos[1] = 700;
        score_pos[2] = 500;
        score_pos[3] = 375;
        score_pos[4] = 250;
        score_pos[5] = 150;
        score_pos[6] = 100;
        score_pos[7] = 80;
        score_pos[8] = 50;
        score_pos[9] = highest_score;

       
        for(int i = 8; i >= 0; i--)
        {
            if(highest_score > score_pos[i])
            {
                score_pos[i + 1] = score_pos[i];
                score_pos[i] = highest_score;            
            }
        }

        for(int i = 0; i < 10; i++)
        {
            score_text[i].text = score_pos[i].ToString();
        }

        for (int i = 0; i < 10; i++)
        {
            if (score_pos[i] == highest_score)
            {

                StartCoroutine(Change_Color(i));
            }
        }
    }


    IEnumerator Change_Color(int i)
    {
      

        float change_factor = 0;
        bool flag = true;
        while (true)
        {
            if(score_text[i].color.a > 1)
            {
                flag = false;
            }

            if (score_text[i].color.a < 1 && flag)
            {
                flag = true;
                change_factor += 0.01f;
            }
            else
            {             
                change_factor -= 0.01f;
                if (score_text[i].color.a < 0.2f)
                    flag = true;
            }
           
            score_text[i].color = new Color(0.135849f, 0.9767407f, 1f, change_factor);
            yield return new WaitForSeconds(0.01f);
        }
    }

  
}
