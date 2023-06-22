using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transitionAnim;
    public float transitionTime = 1f;

    public void ChangeScene(string sceneName)
    {
        Debug.Log("Button Clicked");
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("start");
        Time.timeScale = 1;
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("called");
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
