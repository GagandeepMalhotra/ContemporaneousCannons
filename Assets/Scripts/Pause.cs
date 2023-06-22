using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Canvas pauseCanvas;
    public bool pause = false;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GoalGroup").GetComponent<TwoGoalReached>().enablePause == true && 
            ((Input.GetKeyDown("space")) || (Input.GetKeyDown("p")) || (Input.GetKeyDown("backspace")) || (Input.GetKeyDown("escape"))))
        {
            if (pause == false)
            {
                //FindObjectOfType<AudioManager>().Play("ButtonSmall");
                Time.timeScale = 0;
                pauseCanvas.gameObject.SetActive(true);
                pause = true;
            }
            else
            {
                //FindObjectOfType<AudioManager>().Play("ButtonSmall");
                pauseCanvas.gameObject.SetActive(false);
                pause = false;
                Time.timeScale = 1;
            }
        }
    }
}
