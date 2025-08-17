using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Time.deltaTime example.
//
// Wait two seconds and display waited time.
// This is typically just beyond 2 seconds.
// Allow the speed of the time to be increased or decreased.
// It can range between 0.5 and 2.0. These changes only
// happen when the timer restarts.

public class Timers : MonoBehaviour
{
    private float waitTime = 0.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private int width, height;
    private float value = 10.0f;
    private float scrollBar = 1.0f;
    private int labelPosX = -130;
    private int labelPosY = 15;

    void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        Time.timeScale = scrollBar;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            visualTime = timer;

            // Remove the recorded 2 seconds.
            timer = timer + waitTime;
            Time.timeScale = scrollBar;
        }
    }

    void OnGUI()
    {

        GUIStyle sliderThumbDetails = new GUIStyle(GUI.skin.GetStyle("horizontalSliderThumb"));
        GUIStyle labelDetails = new GUIStyle(GUI.skin.GetStyle("label"));

        // Display the recorded time in a certain size.

        labelDetails.alignment = TextAnchor.UpperRight;
        labelDetails.fontSize = 8 * (width / 200);
        GUI.Label(new Rect(labelPosX,labelPosY,width , height ),
        
            "Time " + visualTime.ToString("f4") + " seconds.", labelDetails);
    }
}