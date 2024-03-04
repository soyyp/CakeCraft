using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public Text scoreText;
    private int currLevel = 3;
    private int boxesLeft = 5;
    private int time = 40;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (SceneManager.GetActiveScene().name != "MainMenu" 
                                                 && SceneManager.GetActiveScene().name != "PauseMenu"
                                                 && SceneManager.GetActiveScene().name != "Tutorial"
                                                 && SceneManager.GetActiveScene().name != "Credits")) 
        {
            PauseGame();
        }

        if (boxesLeft == 0) {
            if (currLevel != 5) {
                NextLevel();
            } else {
                YouWin();
            }
        }
    }

    public void UpdateScore(int boxes) {
        boxesLeft = boxesLeft - boxes;
        UpdateScoreText();
    }

    void UpdateScoreText() {
        if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "GameOver") {
            scoreText.text = "Boxes Left: " + boxesLeft;
        }
    }

    public int getTime() {
        return time;
    }

    public void StartGame() {
        SceneManager.LoadScene("Level2");
        UpdateScore(0);
    }

    void PauseGame() {
        SceneManager.LoadScene("PauseMenu");
    }

    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    void NextLevel() {
        currLevel++;
        boxesLeft = 3 + 2 * (currLevel - 1);
        time = 20 + 20 * (currLevel - 1);
        SceneManager.LoadScene("Level" + currLevel);
        UpdateScore(0);
    }

    void YouWin() {
        SceneManager.LoadScene("YouWin");
    }

    public void ResumeGame() {
        SceneManager.LoadScene("Level" + currLevel);
    }

    public void QuitGame() {
        SceneManager.LoadScene("MainMenu");
    }
}
