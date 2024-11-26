using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]private Animator TransitionAnim;
    [SerializeField]private float TransitionTime;

    public void LoadNextScene(int _SceneIndex)
    {
        StartCoroutine(LoadScene(_SceneIndex));
    }

    IEnumerator LoadScene(int SceneIdex)
    {
        TransitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene(SceneIdex);
    }

    //Ui Buutons onclick Function //
    public void Story()
    {
        LoadNextScene(4);
    }

    public void StartPlay()
    {
        LoadNextScene(1);
    }

    public void Retry()
    {
        LoadNextScene(1);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        LoadNextScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    } 

}
