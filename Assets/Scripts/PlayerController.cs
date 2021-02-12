using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float upperLimit = 5;
    [SerializeField] private float upForce = 5;
    [SerializeField] private float rotationSpeed = 5;
    private GameManager gameManager;
    public bool isGameOver;
    private Quaternion initialRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerRb.velocity = new Vector2(0, 0);
                playerRb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
                transform.rotation = initialRotation;
            }


            if (transform.eulerAngles.z < 90 || transform.eulerAngles.z > 270)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
            }

            if (transform.position.y >= upperLimit)
            {
                playerRb.velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            playerRb.velocity = new Vector2(0, 0);
            isGameOver = true;
            gameManager.GameOver();
        }        

        if(collision.CompareTag("ScoreSensor"))
        {
            gameManager.UpdateScore();
        }

        if (collision.CompareTag("BottomSensor"))
        {
            isGameOver = true;
            gameManager.GameOver();
        }
    }
}
