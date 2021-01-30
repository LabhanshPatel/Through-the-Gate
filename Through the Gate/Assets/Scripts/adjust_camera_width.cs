using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjust_camera_width : MonoBehaviour
{
    private Camera camera;
    private float sceneWidth = 20;


    void Start()
    {
        camera = GetComponent<Camera>();
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        camera.orthographicSize = desiredHalfHeight;
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    
}