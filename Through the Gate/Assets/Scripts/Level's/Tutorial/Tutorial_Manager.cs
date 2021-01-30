using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Tutorial_Object
{
    public Scriptable_Obj scriptable_obj;
    public TextMeshProUGUI description;
}


public class Tutorial_Manager : MonoBehaviour
{

    [SerializeField] private Tutorial_Object Tutorial_object = new Tutorial_Object();
    [SerializeField] Animation animation_manager;

    private Audio_Manager audio_manager;

    private int description_index = 0;
    void Start()
    {
        audio_manager = GameObject.Find("Audio Manager").GetComponent<Audio_Manager>();
        Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
    }

    public void On_Click_Next_Button()
    {
        audio_manager.Play("Button");

        if (description_index == 0)
            StartCoroutine(Play_Touch_Left());
        else if (description_index == 1)
            StartCoroutine(Play_Right_Left());
        else if (description_index == 2)
            StartCoroutine(Play_Level_Up());
        else if (description_index == 3)
            StartCoroutine(Play_Game_Over());
        else if (description_index == 4)
            StartCoroutine(Play_Above_Blocks());
        else if (description_index == 5)
            StartCoroutine(Play_Below_Blocks());
        else if (description_index >= 6)
            Next_Description();
    }

    IEnumerator Play_Touch_Left()
    {

        description_index++;
        Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
        animation_manager.Play("touch_left");
        yield return new WaitForSeconds(0.5f);
        
    }

    IEnumerator Play_Right_Left()
    {
      
        animation_manager.Play("touch_right");
        yield return new WaitForSeconds(.5f);
        description_index++;
        Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
    }

    IEnumerator Play_Level_Up()
    {
        GameObject.Find("Player").SetActive(false);
        GameObject.Find("Tutorial Manager").transform.Find("Canvas").transform.Find("Hand").gameObject.SetActive(false);
        animation_manager.Play("level_up");
        yield return new WaitForSeconds(.5f);
        description_index++;
        Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
    }

    IEnumerator Play_Game_Over()
    {
        animation_manager.Play("game_over");
        yield return new WaitForSeconds(.5f);
        description_index++;
        Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
    }

    IEnumerator Play_Above_Blocks()
    {
        GameObject.Find("Tutorial Manager").transform.Find("Canvas").transform.Find("top left").gameObject.SetActive(false);
        GameObject.Find("Tutorial Manager").transform.Find("Canvas").transform.Find("top right").gameObject.SetActive(false);

        animation_manager.Play("above_blocks");
        yield return new WaitForSeconds(.5f);
        description_index++;
        Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
    }

    IEnumerator Play_Below_Blocks()
    {

        animation_manager.Play("below_blocks");
        yield return new WaitForSeconds(.5f);
        description_index++;
        Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
    }

    private void Next_Description()
    {
        if (description_index == 6)
        {
            animation_manager.Play("so_be_clever");
            GameObject.Find("Tutorial Manager").transform.Find("Canvas").transform.Find("Below Blocks").gameObject.SetActive(false);
            description_index++;
            Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
        }
        else if (description_index == 9)
        {
            PlayerPrefs.SetInt("Show_Tutorial", 1);
            SceneManager.LoadScene(0);
        }
        else
        {
            description_index++;
            Tutorial_object.description.text = Tutorial_object.scriptable_obj.description[description_index];
        }
    }
}
