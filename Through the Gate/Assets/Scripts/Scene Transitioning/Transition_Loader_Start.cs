using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition_Loader_Start : MonoBehaviour
{
    Audio_Manager audio_manager; 
    [SerializeField] Animator scene_transition;
    private Scene_Loader scene_loader;


    void Start()
    {              
  
        scene_loader = FindObjectOfType<Scene_Loader>().GetComponent<Scene_Loader>();

        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();

        if (Scene_Loader.scene_index == 1 || Scene_Loader.scene_index == 9)
        {
            StartCoroutine(Wait_Before_Destroy());
          //  scene_transition.SetBool("start_transition", true);
        }

    }


    IEnumerator Wait_Before_Destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(GameObject.Find("(start)Scene Transitioning"));
        Destroy(this.gameObject);
    }


    public void On_Click_Start_Button()
    {
        StartCoroutine(Wait_Before_Load_Start_Button());
    }
    public void On_Click_Stats_Button()
    {
        StartCoroutine(Wait_Before_Load_Stats_Button());
    }

    public void On_Click_Credits_Button()
    {
        StartCoroutine(Wait_Before_Load_Credits_Button());
    }

    public void On_Click_Info_Button()
    {
        StartCoroutine(Wait_Before_Load_Info_Button());
    }

    public void On_Click_Back_Button()
    {
        StartCoroutine(Wait_Before_Load_Back_Button());
    }




    IEnumerator Wait_Before_Load_Stats_Button()
    {
        audio_manager.Play("Button");
        scene_transition.SetBool("end_transition", true);
        yield return new WaitForSeconds(1f);

        scene_loader.Load_Scene_By_Index(18);
    }

    IEnumerator Wait_Before_Load_Credits_Button()
    {
        audio_manager.Play("Button");
        scene_transition.SetBool("end_transition", true);
        yield return new WaitForSeconds(1f);

        scene_loader.Load_Scene_By_Index(19);
    }

    IEnumerator Wait_Before_Load_Info_Button()
    {
        audio_manager.Play("Button");
        scene_transition.SetBool("end_transition", true);
        yield return new WaitForSeconds(1f);

        scene_loader.Load_Scene_By_Index(20);
    }
    IEnumerator Wait_Before_Load_Start_Button()
    {

        GameObject.Find("Audio Manager").GetComponent<Audio_Manager>().Play("Button");
        scene_transition.SetBool("end_transition", true);

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    IEnumerator Wait_Before_Load_Back_Button()
    {

        GameObject.Find("Audio Manager").GetComponent<Audio_Manager>().Play("Button");
        scene_transition.SetBool("end_transition", true);

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
