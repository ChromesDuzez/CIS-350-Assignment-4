using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to the obstacles moving left
public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //if we are out of bounds to the left and the gameObject is an obstacle destroy this obstacle
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
