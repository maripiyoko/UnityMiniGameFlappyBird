using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject gameOverTextImage;
    public Player player;
    public Text scoreText;

    int score = 0;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        seconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted()) {
            scoreText.gameObject.GetComponent<Text>().text = "" + score;
            seconds += Time.deltaTime;
            Debug.Log("update seconds " + seconds);
        }
    }

    public bool isGameStarted() {
        return !player.isDead;
    }

    public void increasePoint() {
        score++;
    }

    public void StartGame() {
        Debug.Log("seconds " + seconds);
        if (seconds > 0) {
            ReStartGame();
        }
        startButton.gameObject.SetActive(false);
        gameOverTextImage.gameObject.SetActive(false);
        player.Alive();
        Time.timeScale = 1;
        score = 0;
    }

    public void ReStartGame() {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameOverTextImage.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
    }
}
