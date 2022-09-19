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

    // Start is called before the first frame update
    void Start()
    {
        //Set reference variables to components
        rb = GetComponent<Rigidbody>();

        //Modify gravity
        //Physics.gravity *= gravityModifier;
        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Press spacebar to jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;

            //Play dirt particle
            //dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("GameOver!");
            gameOver = true;

            //Play death animation
            //playerAnimator.SetBool("Death_b", true);
            //playerAnimator.SetInteger("DeathType_int", 1);

            //Play explosion particle
            //explosionParticle.Play();

            //Stop playing dirt particle
            //dirtParticle.Stop();


        }
    }
}
