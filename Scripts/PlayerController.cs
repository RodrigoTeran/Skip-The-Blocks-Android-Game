using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocity = 5f;
    private Rigidbody2D playerCube;
    public ParticleSystem particles;
    bool CanLeft = false;
    bool CanRight = false;

    public Text score;

    public Canvas canvas;
    public GameObject Egen;

    float leftBound = -4.7f;
    float rightBound = 12.5f;


    List<string> keys = new List<string>();
    
    void Start(){
        keys.Add(".");
        keys.Add(".");
        keys.Add(".");
        keys.Add(".");
    }

    bool really = false;

    public void ReallyStart()
    {
        really = true;
    }

    public void EndGame()
    {
        really = false;
        Destroy(gameObject);
    }

    public int scores = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            canvas.SendMessage("EndGame");
            Egen.SendMessage("Cancel");
        }
        if(other.tag == "Coin")
        {
            scores += 1;
            score.text = "Score: " + scores;
            canvas.SendMessage("ACoin");
        }
    }

    void Update()
    {
        if (really)
        {
            bool userLeft = false;
            bool userRight = false;
            // Cube
            playerCube = GetComponent<Rigidbody2D>();

            bool click = Input.GetMouseButtonDown(0);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (click)
            {
                if (worldPoint.x > 0)
                {
                    userRight = true;
                }
                else
                {
                    userLeft = true;
                }
            }

            if (userLeft)
            {
                // solo izq
                CanLeft = true;

                var lastKey = keys[keys.Count - 1];
                if (lastKey != "l")
                {
                    keys.Add("l");
                }
            }
            if (userRight)
            {
                // solo derecha
                CanRight = true;

                var lastKey = keys[keys.Count - 1];
                if (lastKey != "r")
                {
                    keys.Add("r");
                }
            }

            // Key up
            if (Input.GetMouseButtonUp(0))
            {
                if (worldPoint.x < 0)
                {
                    playerCube.velocity = Vector2.left * 0;
                    CanLeft = false;
                }
                else
                {
                    playerCube.velocity = Vector2.right * 0;
                    CanRight = false;
                }
            }

            // Move
            if (keys[keys.Count - 2] == "l" && keys[keys.Count - 1] == "r")
            {
                if (CanLeft)
                {
                    if (playerCube.position.x <= leftBound)
                    {
                        playerCube.velocity = Vector2.left * 0;
                    }
                    else
                    {
                        playerCube.velocity = Vector2.left * velocity * Time.deltaTime * 100;
                        particles.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    }
                }
                if (CanRight)
                { // tiene prioridad
                    if (playerCube.position.x >= rightBound)
                    {
                        playerCube.velocity = Vector2.right * 0;
                    }
                    else
                    {
                        playerCube.velocity = Vector2.right * velocity * Time.deltaTime * 100;
                        particles.transform.localRotation = Quaternion.Euler(0, -90, 0);
                    }
                }
            }
            else
            {
                if (CanRight)
                {
                    if (playerCube.position.x >= rightBound)
                    {
                        playerCube.velocity = Vector2.right * 0;
                    }
                    else
                    {
                        playerCube.velocity = Vector2.right * velocity * Time.deltaTime * 100;
                        particles.transform.localRotation = Quaternion.Euler(0, -90, 0);
                    }
                }
                if (CanLeft)
                {   // tiene prioridad
                    if (playerCube.position.x <= leftBound)
                    {
                        playerCube.velocity = Vector2.left * 0;
                    }
                    else
                    {
                        playerCube.velocity = Vector2.left * velocity * Time.deltaTime * 100;
                        particles.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    }
                }
            }
            if (CanLeft == false && CanRight == false)
            {
                particles.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
