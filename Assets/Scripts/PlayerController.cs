using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float acceleration = 2.5f;
    private float verticalInput;
    public float horizontalInput;
    private Animator ani;
    public float cleaningInput;
    public float attackingInput;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Cleaning();
        Attacking();
    }

    void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.up * verticalInput * acceleration * Time.deltaTime);
        transform.Translate(Vector2.right * horizontalInput * acceleration * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            acceleration = 5.0f;
            if (horizontalInput > 0)
            {
                ani.SetFloat("horiX", 1.5f);
            }
            else if (horizontalInput < 0)
            {
                ani.SetFloat("horiX", -1.5f);
            }
        }
        else
        {
            acceleration = 2.5f;
            ani.SetFloat("horiX", horizontalInput);
        }

        if (verticalInput != 0)
        {
            ani.SetFloat("vertX", 1);
        }
        else
        {
            ani.SetFloat("vertX", 0);
        }
    }

    void Cleaning()
    {
        cleaningInput = Input.GetAxis("RightClick");

        // Animation
        if(cleaningInput != 0)
        {
            ani.SetBool("cleaning", true);
        }
        else
        {
            ani.SetBool("cleaning", false);
        }
    }

    void Attacking()
    {
        attackingInput = Input.GetAxis("LeftClick");

        if(attackingInput != 0)
        {
            ani.SetBool("attacking", true);
        }
        else
        {
            ani.SetBool("attacking", false);
        }
    }
}
