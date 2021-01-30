using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Show_Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI Final_score_text;

    private void Awake()
    {
        Destroy(GameObject.Find("Score_UI_Manager"));
    }
    void Start()
    {


        if (Scene_Loader.scene_index == 13)
            score_text.text = Carry_Current_Score.current_score.ToString();


        if (Scene_Loader.scene_index == 12)
        {
            int final_score = Carry_Current_Score.current_score + 300;

            score_text.text = "Final Score : \n" + Carry_Current_Score.current_score.ToString() + " + Bonus Score = ";
            Final_score_text.text = final_score.ToString();

            Carry_Current_Score.current_score += 300;

        }


        if (PlayerPrefs.GetInt("Highest_Score") < Carry_Current_Score.current_score)
        {
            PlayerPrefs.SetInt("Highest_Score", Carry_Current_Score.current_score);
        }

        
    }

}
