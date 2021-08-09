using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int score = 0;

    public float speed = 5f;
    public Image winloseBG;
    public int health = 5;
    public Rigidbody rb;
    public Text healthText;
    public Text scoreText;
    public Text winloseText;


    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Object.Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            winloseText.text = "You Win!";
            winloseText.color = Color.black;
            winloseBG.color = Color.green;
            winloseBG.gameObject.SetActive(true);
        }
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            winloseText.text = "Game Over!";
            winloseText.color = Color.white;
            winloseBG.color = Color.red;
            winloseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKey("escape"))
            SceneManager.LoadScene("menu");
    }
}