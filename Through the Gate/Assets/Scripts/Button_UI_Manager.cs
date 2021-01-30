using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_UI_Manager : MonoBehaviour
{
    [SerializeField] Animator scene_transition;

    private Audio_Manager audio_manager;
    void Start()
    {
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
    }


    public void Yes_Selected()
    {
        StartCoroutine(Wait_Before_Load_Yes_Button());
    }

    public void No_Selected()
    {
        StartCoroutine(Wait_Before_Load_No_Button());
    }

    public void Easy_Selected()
    {
        StartCoroutine(Wait_Before_Load_Easy_Button());
    }
    public void Medium_Selected()
    {
        StartCoroutine(Wait_Before_Load_Medium_Button());
    }
    public void Hard_Selected()
    {
        StartCoroutine(Wait_Before_Load_Hard_Button());
    }

    IEnumerator Wait_Before_Load_Yes_Button()
    {
        audio_manager.Play("Button");
        scene_transition.SetBool("end_transition", true);
        yield return new WaitForSeconds(1f);    
        SceneManager.LoadScene(14);
    }

    IEnumerator Wait_Before_Load_No_Button()
    {
        audio_manager.Play("Button");
        scene_transition.SetBool("end_transition", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(9);
    }

    IEnumerator Wait_Before_Load_Easy_Button()
    {
        audio_manager.Play("Button");
        scene_transition.SetBool("end_transition", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(15);
    }

    IEnumerator Wait_Before_Load_Medium_Button()
    {
        audio_manager.Play("Button");
        scene_transition.SetBool("end_transition", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(16);
    }

    IEnumerator Wait_Before_Load_Hard_Button()
    {
        audio_manager.Play("Button");
        scene_transition.SetBool("end_transition", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(17);
    }
}
