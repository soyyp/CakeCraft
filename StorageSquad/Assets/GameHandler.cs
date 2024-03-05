using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    private int currLevel;
    private int boxesLeft;
    private float time;
    private float gameTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currLevel = getLevel();
        UpdateScore(0);
        UpdateTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxesLeft == 0) {
            if (currLevel != 5) {
                NextLevel();
            } else {
                YouWin();
            }
        }
    }

    void FixedUpdate() {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2"
                                                           || SceneManager.GetActiveScene().name == "Level3"
                                                           || SceneManager.GetActiveScene().name == "Level4"
                                                           || SceneManager.GetActiveScene().name == "Level5") 
        {
            gameTimer += 0.02f;
            if (gameTimer >= 1f) {
                time -= 1;
                gameTimer = 0;
                UpdateTime();
            }
            if (time <= 0) {
                time = 0;
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void UpdateScore(int boxes) {
        boxesLeft -= boxes;
        UpdateScoreText();
    }

    public void UpdateTime() {
        if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "GameOver"
                                                             && SceneManager.GetActiveScene().name != "Credits"
                                                             && SceneManager.GetActiveScene().name != "Tutorial"
                                                             && SceneManager.GetActiveScene().name != "PauseMenu"
                                                             && SceneManager.GetActiveScene().name != "YouWin")
        {
            timeText.text = "Time: " + time;
        }
    }

    void UpdateScoreText() {
        if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "GameOver"
                                                             && SceneManager.GetActiveScene().name != "Credits"
                                                             && SceneManager.GetActiveScene().name != "Tutorial"
                                                             && SceneManager.GetActiveScene().name != "PauseMenu"
                                                             && SceneManager.GetActiveScene().name != "YouWin")
        {
            scoreText.text = "Boxes Left: " + boxesLeft;
        }
    }

    public float getTime() {
        return time;
    }

    int getLevel() {
        if (SceneManager.GetActiveScene().name == "Level2") {
            boxesLeft = 5;
            time = 40;
            return 2;
        } else if (SceneManager.GetActiveScene().name == "Level3") {
            boxesLeft = 7;
            time = 60;
            return 3;
        } else if (SceneManager.GetActiveScene().name == "Level4") {
            boxesLeft = 9;
            time = 75;
            return 4;
        } else if (SceneManager.GetActiveScene().name == "Level5") {
            boxesLeft = 11;
            time = 90;
            return 5;
        } else {
            boxesLeft = 3;
            time = 20;
            return 1;
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("Level1");
        UpdateScore(0);
    }

    public void Tutorial() {
        SceneManager.LoadScene("Tutorial");
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    void NextLevel() {
        currLevel++;
        if (SceneManager.GetActiveScene().name == "Level1") {
            SceneManager.LoadScene("Level2");
        } else if (SceneManager.GetActiveScene().name == "Level2") {
            SceneManager.LoadScene("Level3");
        } else if (SceneManager.GetActiveScene().name == "Level3") {
            SceneManager.LoadScene("Level4");
        } else if (SceneManager.GetActiveScene().name == "Level4") {
            SceneManager.LoadScene("Level5");
        }
    }

    void YouWin() {
        SceneManager.LoadScene("YouWin");
    }

    public void QuitGame() {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame() {
            Time.timeScale = 1f;
            GameHandler_PauseMenu.GameisPaused = false;
            SceneManager.LoadScene("Level1");
      }

      // Replay the Level where you died
      public void ReplayLastLevel() {
            Time.timeScale = 1f;
            GameHandler_PauseMenu.GameisPaused = false;
            currLevel = getLevel();
            SceneManager.LoadScene("Level" + currLevel);
            // Reset all static variables here, for new games:
            time = 20 + (20 * (currLevel - 1));
            boxesLeft = 3 + (2 * (currLevel - 1));
      }
}
