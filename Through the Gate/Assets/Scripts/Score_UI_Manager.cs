using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Score_UI_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score_text;
    private SpriteRenderer player_color;
    private void Start()
    {
        player_color = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        score_text.text = Carry_Current_Score.current_score.ToString();
    }


    public void Increase_Score(int score_value)
    {            
        Carry_Current_Score.current_score += score_value;

        StartCoroutine(Increase_Score());

    }

    public void Decrease_Score(int score_value)
    {
        if(Carry_Current_Score.current_score >= 10)
            Carry_Current_Score.current_score -= score_value;

        StartCoroutine(Decrease_Score());
    }

    IEnumerator Decrease_Score()
    {
        score_text.text = Carry_Current_Score.current_score.ToString();
    
        player_color.color = new Color(0.6037736f, 0.01869413f, 0f);// red
        yield return new WaitForSeconds(0.1f);


        player_color.color = new Color(0.3776433f, 0.6415094f, 0.6163793f); // original
        yield return new WaitForSeconds(0.1f);

        player_color.color = new Color(0.6037736f, 0.01869413f, 0f);// red
        yield return new WaitForSeconds(0.1f);

        player_color.color = new Color(0.3776433f, 0.6415094f, 0.6163793f); // original
        yield return new WaitForSeconds(0.1f);

        player_color.color = new Color(0.6037736f, 0.01869413f, 0f);// red
        yield return new WaitForSeconds(0.1f);

        player_color.color = new Color(0.3776433f, 0.6415094f, 0.6163793f); // original

    }


    IEnumerator Increase_Score()
    {
        score_text.text = Carry_Current_Score.current_score.ToString();
   
        player_color.color = new Color(1f, 0.9222843f, 0.01423675f);// yellow
        yield return new WaitForSeconds(0.1f);
    
        player_color.color = new Color(0.3776433f, 0.6415094f, 0.6163793f); // original
        yield return new WaitForSeconds(0.1f);
  
        player_color.color = new Color(1f, 0.9222843f, 0.01423675f);// yellow
        yield return new WaitForSeconds(0.1f);
    
        player_color.color = new Color(0.3776433f, 0.6415094f, 0.6163793f); // original
        yield return new WaitForSeconds(0.1f);
   
        player_color.color = new Color(1f, 0.9222843f, 0.01423675f);// yellow
        yield return new WaitForSeconds(0.1f);
  
        player_color.color = new Color(0.3776433f, 0.6415094f, 0.6163793f); // original

    }
}
