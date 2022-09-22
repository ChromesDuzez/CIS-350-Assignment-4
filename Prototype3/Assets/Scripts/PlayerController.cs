/* 
 * Zach Wilson
 * CIS 350 Assignment 4
 * This script manages the player object and the user input (i.e. jump)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to player object
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //Set reference variables to components
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        //Modify gravity
        //Physics.gravity *= gravityModifier;
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

        //Start Running
        playerAnimator.SetFloat("Speed_f", 1.0f);

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Press spacebar to jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            //set the trigger to play the jump animation
            playerAnimator.SetTrigger("Jump_trig");
            //Stop playing dirt particle
            dirtParticle.Stop();

            //Play Jump Sound Effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;

            //Play dirt particle
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("GameOver!");
            gameOver = true;


            //Stop playing dirt particle
            dirtParticle.Stop();

            //Play Crash Sound Effect
            playerAudio.PlayOneShot(crashSound, 1.0f);

            //Play explosion particle
            explosionParticle.Play();

            //set death animation type
            playerAnimator.SetInteger("DeathType_int", 1);
            //set the dead parameter to true / play death animation
            playerAnimator.SetBool("Death_b", true);
        }
    }
}
