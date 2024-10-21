using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DustCleaning : MonoBehaviour
{
    public GameObject Player;
    private PlayerController playerControllerScript;
    private float offset = 0.22f;
    public GameObject pressToCleanText;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.horizontalInput > 0)
        {
            transform.position = new Vector2(Player.transform.position.x + offset, Player.transform.position.y);
        }
        else if (playerControllerScript.horizontalInput < 0)
        {
            transform.position = new Vector2(Player.transform.position.x - offset, Player.transform.position.y);
        }
    }

    private void OnTriggerStay2D(Collider2D dust)
    {
        if(dust.gameObject.tag == "Dusts")
        {
            pressToCleanText.SetActive(true);
        }
        else
        {
            pressToCleanText.SetActive(false);
        }
        if (playerControllerScript.cleaningInput != 0 && dust.gameObject.tag == "Dusts")
        {
            DustInfo dustInfo = dust.gameObject.GetComponent<DustInfo>();
            dustInfo.dustHp -= 5;
            Debug.Log(dustInfo.dustHp);
            if (dustInfo.dustHp <= 0)
            {
                Destroy(dust.gameObject);
                playerControllerScript.cleaningSuccessful.Play();
            }
        }
    }
}
