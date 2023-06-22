using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwoGoalReached : MonoBehaviour
{
    public int nextSceneLoad;
    public bool enablePause = true;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
        }

        if(GameObject.FindGameObjectWithTag("Goal1").GetComponent<GoalOne>().goal1 == true &&
            GameObject.FindGameObjectWithTag("Goal2").GetComponent<GoalTwo>().goal2 == true)
        {
            enablePause = false;
            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                StartCoroutine(Wait(2f));
            }
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }

        SceneManager.LoadScene(nextSceneLoad);
    }
}
