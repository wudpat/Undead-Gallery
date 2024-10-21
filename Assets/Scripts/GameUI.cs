using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI pictureLeftText;
    private int picLeft;
    public GameObject picLeftButton;
    private PlayerController playerControllerScript;
    public GameObject gameOverText;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] picLeft = GameObject.FindGameObjectsWithTag("Dusts");
        int picLeftCount = picLeft.Length;
        string numLeft = picLeftCount.ToString();
        string manyPics = numLeft + " pictures left";
        string onePics = numLeft + " picture left";
        string done = "Done";

        if(numLeft != "1")
        {
            pictureLeftText.text = manyPics;
        }
        else if(numLeft == "1")
        {
            pictureLeftText.text = onePics;
        }
        else if(numLeft == "0")
        {
            pictureLeftText.text = done;
        }

        if (playerControllerScript.death)
        {
            picLeftButton.SetActive(false);
            gameOverText.SetActive(true);
            sceneTransition();
        }
    }

    void sceneTransition()
    {
        timer += Time.deltaTime;

        if(timer >= 3)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
