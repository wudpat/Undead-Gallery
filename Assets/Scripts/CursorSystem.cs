using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorSystem : MonoBehaviour
{
    [SerializeField]
    private Texture2D normalCursorTexture;
    [SerializeField]
    private Texture2D gameCursorTexture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CursorUpdate();
    }
    void CursorUpdate()
    {
        if (SceneManager.GetActiveScene().name != "Game")
        {
            Cursor.SetCursor(normalCursorTexture, Vector2.zero, CursorMode.Auto);
        }
        else if (SceneManager.GetActiveScene().name == "Game")
        {
            Cursor.SetCursor(gameCursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }
}
