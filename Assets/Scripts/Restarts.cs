using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restarts : MonoBehaviour
{
    public void LoadMap()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
