using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButton : MonoBehaviour
{
    public void LoadMap()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
