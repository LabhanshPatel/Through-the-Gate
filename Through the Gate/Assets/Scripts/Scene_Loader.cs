using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Scene_Loader : MonoBehaviour
{
    public static int scene_index;
    Audio_Manager audio_manager;

    private AudioSource music_audio_manager;

    [SerializeField] TextMeshProUGUI highest_score;
    [SerializeField] GameObject Pause_UI;

    void Awake()
    {           
        scene_index = SceneManager.GetActiveScene().buildIndex;     
    }

    private void Start()
    {
        if(scene_index == 0)
        highest_score.text = "Highest Score:  " + PlayerPrefs.GetInt("Highest_Score").ToString();

        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
        music_audio_manager = audio_manager.GetComponent<AudioSource>();

        if (scene_index == 13)
        {         
            StartCoroutine(Destroy_Audio_Manager());
        }

        if(scene_index == 1)
        {
            GameObject.Find("Life's").transform.Find("Canvas").gameObject.SetActive(true);
        }
    }


    public void Load_Next_Scene()
    {
        SceneManager.LoadScene(scene_index + 1);
    }

    public void On_Click_Play_Again_Button()
    {
        Ball.Lifes = 3;

        GameObject.Find("Life's").transform.Find("Canvas").transform.Find("1").gameObject.SetActive(true);
        GameObject.Find("Life's").transform.Find("Canvas").transform.Find("2").gameObject.SetActive(true);
        GameObject.Find("Life's").transform.Find("Canvas").transform.Find("3").gameObject.SetActive(true);
        GameObject.Find("Life's").SetActive(false);


        StartCoroutine(Wait_Before_Load());     
    }

    public void Load_Game_Over_Scene()
    {
        SceneManager.LoadScene(13);
    }

    public void Load_Scene_By_Index(int index)
    {
        SceneManager.LoadScene(index);
    }

   
    public void Load_Current_Scene()
    {
        SceneManager.LoadScene(scene_index);
    }

    public void On_Click_Quit_Button()
    {
        Application.Quit();
    }

    public void On_Click_Pause_Button()
    {
        Time.timeScale = 0;
        Pause_UI.SetActive(true);
    }

    public void On_Click_Resume_Button()
    {
        Time.timeScale = 1;
        audio_manager.Play("Button");
        Pause_UI.SetActive(false);

    }

    public void On_Click_MainMenu_Button()
    {
        Time.timeScale = 1;
        Ball.Lifes = 3;

        GameObject.Find("Life's").transform.Find("Canvas").transform.Find("1").gameObject.SetActive(true);
        GameObject.Find("Life's").transform.Find("Canvas").transform.Find("2").gameObject.SetActive(true);
        GameObject.Find("Life's").transform.Find("Canvas").transform.Find("3").gameObject.SetActive(true);
        GameObject.Find("Life's").SetActive(false);

        StartCoroutine(Wait_Before_Load());
    }

    IEnumerator Destroy_Audio_Manager()
    {
    
        audio_manager.flag = true;
        float change_factor = 0.1f;

        while (change_factor > 0)
        {
            music_audio_manager.volume = change_factor;
            change_factor -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
             
    }

    IEnumerator Wait_Before_Load()
    {
        audio_manager.Play("Button");
        Carry_Current_Score.current_score = 0;

        yield return new WaitForSeconds(0.35f);

        Destroy(GameObject.Find("Audio Manager"));
        SceneManager.LoadScene(0);
    }

   
}