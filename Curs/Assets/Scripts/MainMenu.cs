using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayCurrentLevel()
    {
        SceneManager.LoadScene(2);
        Destroy(GameObject.Find("Audio Source"));
    }
    public void OpenLevelList()
    {
        SceneManager.LoadScene(1);
    }
}
