using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerController : MonoBehaviour
{
    private float acceleration = 2.5f;
    private float verticalInput;
    public float horizontalInput;
    private Animator ani;
    public float cleaningInput;
    public float attackingInput;
    public bool death;
    public string inRoom;
    private bool freezed;
    [SerializeField]
    private AudioSource walkingSound;
    [SerializeField]
    private AudioSource runningSound;
    private bool walkPlaying;
    private bool runPlaying;
    [SerializeField]
    private AudioSource shootingSound;
    public AudioSource enemyDie;
    public AudioSource cleaningSound;
    public AudioSource cleaningSuccessful;
    private bool cleanSoundPlayed;

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
        
        // Animation and acceleration stuff
        if (Input.GetKey(KeyCode.LeftShift) && freezed == false)
        {
            acceleration = 4.0f;
            if (horizontalInput > 0)
            {
                ani.SetFloat("horiX", 1.5f);
            }
            else if (horizontalInput < 0)
            {
                ani.SetFloat("horiX", -1.5f);
            }
        }
        else if(freezed == false)
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
        
        // Adjusting onRight parameter for playing attacking/cleaning animation properly
        if(horizontalInput > 0)
        {
            ani.SetFloat("onRight", 1);
        }
        else if(horizontalInput < 0)
        {
            ani.SetFloat("onRight", -1);
        }

        // Applying onRight to horiX for idle direction
        if(ani.GetFloat("onRight") == 1 && horizontalInput == 0)
        {
            ani.SetFloat("horiX", 0.5f);
        }
        else if(ani.GetFloat("onRight") == -1 && horizontalInput == 0)
        {
            ani.SetFloat("horiX", -0.5f);
        }

        // Sound Controller
        if(((verticalInput != 0 || horizontalInput != 0) && Input.GetKey(KeyCode.LeftShift)))
        {
            if (!runPlaying)
            {
                runPlaying = true;
                walkPlaying = false;
                runningSound.Play();
                walkingSound.Stop();
            }
        }
        else if((verticalInput != 0 || horizontalInput != 0) && !walkPlaying)
        {
            walkPlaying = true;
            runPlaying = false;
            walkingSound.Play();
            runningSound.Stop();
        }
        else if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            walkPlaying = false;
            runPlaying = false;
            walkingSound.Stop();
            runningSound.Stop();
        }
    }

    void Cleaning()
    {
        if(attackingInput == 0)
        {
            cleaningInput = Input.GetAxis("RightClick");

            // Animation
            if (cleaningInput != 0)
            {
                acceleration = 0;
                freezed = true;
                ani.SetBool("cleaning", true);
                if (!cleanSoundPlayed)
                {
                    cleaningSound.Play();
                    cleanSoundPlayed = true;
                }
            }
            else
            {
                if(acceleration == 0)
                {
                    acceleration = 2.5f;
                }
                freezed = false;
                ani.SetBool("cleaning", false);
                cleaningSound.Stop();
                cleanSoundPlayed = false;
            }
        }
    }

    void Attacking()
    {
        if(cleaningInput == 0)
        {
            attackingInput = Input.GetAxis("LeftClick");

            if (attackingInput != 0)
            {
                ani.SetBool("attacking", true);
                shootingSound.Play();
            }
            else
            {
                ani.SetBool("attacking", false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D enemy)
    {
        if(enemy.gameObject.tag == "Enemies")
        {
            ani.SetTrigger("killed");
            death = true;
            walkingSound.Stop();
            runningSound.Stop();
            this.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D room)
    {
        if(room.name == "EgyptianRoom")
        {
            inRoom = "Egypt";
        }
        else if(room.name == "EuropeanRoom")
        {
            inRoom = "Eu";
        }
        else if(room.name == "ChineseRoom")
        {
            inRoom = "Cn";
        }
        else if(room.name == "CommonRoomSouthWest")
        {
            inRoom = "CommonSW";
        }
        else if(room.name == "CommonRoomSouth")
        {
            inRoom = "CommonS";
        }
    }
}
