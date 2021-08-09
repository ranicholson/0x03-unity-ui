using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int score = 0;

    public float speed = 5f;
    public int health = 5;
    public Rigidbody rb;


    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        
        if (Input.GetKey("a") || Input.GetKey("left"))
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        
        if (Input.GetKey("w") ||  Input.GetKey("up"))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        
        if (Input.GetKey("s") || Input.GetKey("down"))
            rb.AddForce(0, 0, -speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log ("Score: " + score);
            Object.Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }

        if (other.tag == "Goal")
            Debug.Log("You win!");
    }
}