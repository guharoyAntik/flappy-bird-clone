using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject [] pipeConfigs;
    [SerializeField] private Vector3 spawnPosition = new Vector3(5, 0, 0);
    [SerializeField] private float startTime = 3;
    [SerializeField] private float spawnRate = 2;
    private PlayerController playerControllerScript;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    public Button restartButton;
    public int score = 0;
    public int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        highScoreText.text = "Best\n" + highScore;
        playerControllerScript = GameObject.Find("Flappy").GetComponent<PlayerController>();
        InvokeRepeating("CreatePipe", startTime, spawnRate);
    }

    void CreatePipe()
    {
        if (!playerControllerScript.isGameOver)
        {
            int pipeIndex = Random.Range(0, pipeConfigs.Length);
            Instantiate(pipeConfigs[pipeIndex], spawnPosition, pipeConfigs[pipeIndex].transform.rotation);
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {        
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "Best\n" + highScore;
        }
        PlayerPrefs.SetInt("Highscore", highScore);
        PlayerPrefs.Save();
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
