using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition_Loader_Level : MonoBehaviour
{
    Audio_Manager audio_manager;
    [SerializeField] Animator scene_transition;
    private Scene_Loader scene_loader;

    [SerializeField] Image image;
    private void Awake()
    {
    }
    void Start()
    {
        scene_loader = FindObjectOfType<Scene_Loader>().GetComponent<Scene_Loader>();
        audio_manager = FindObjectOfType<Audio_Manager>().GetComponent<Audio_Manager>();
         
        if(Scene_Loader.scene_index != 0 && Scene_Loader.scene_index != 1 && Scene_Loader.scene_index != 9)
        {
              scene_transition.SetBool("level_start", true);
            //    scene_transition.SetBool("level_over", false);
            StartCoroutine(Change_Transition_Color());
        }
    }

    IEnumerator Change_Transition_Color()
    {
        yield return new WaitForSeconds(1.2f);

        if(Scene_Loader.scene_index == 2)
            image.color = new Color(0.1098039f, 0.4156863f, 0.2941177f);
        else if(Scene_Loader.scene_index == 3)
            image.color = new Color(0.1137255f, 0.4103892f, 0.6235294f);
        else if (Scene_Loader.scene_index == 4)
            image.color = new Color(0.754717f, 0.2093271f, 0.3057012f);
        else if (Scene_Loader.scene_index == 5)
            image.color = new Color(0.3411765f, 0.2862745f, 0.2862745f);
        else if (Scene_Loader.scene_index == 6)
            image.color = new Color(0.5566038f, 0.4487714f, 0.3224101f);       
        else if (Scene_Loader.scene_index == 9)
            image.color = new Color(0.3867925f, 0.2021538f, 0.2999018f);
        else if (Scene_Loader.scene_index == 10)
            image.color = new Color(0.8584906f, 0.003239523f, 0.3182044f);
        


    }
}
