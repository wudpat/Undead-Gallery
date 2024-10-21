using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueWait : MonoBehaviour
{
    public GameObject ContinueButton;
    public float delayTime = 2f; 

    void Start()
    {
        ContinueButton.SetActive(false);
        StartCoroutine(ActivateObjectAfterDelay());
    }

    IEnumerator ActivateObjectAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        ContinueButton.SetActive(true);
    }
}
