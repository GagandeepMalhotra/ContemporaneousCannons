using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalReached : MonoBehaviour
{   
    private int nextSceneLoad;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Ball")
        {
            enablePause = false;
            Destroy(other.gameObject);
            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Component halo = GetComponent("Halo"); halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
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
