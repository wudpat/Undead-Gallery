using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class Fade : MonoBehaviour
{
    public Animator transition;
    public GameObject Black;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Black.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("StartCutScene");
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        Black.SetActive(true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
