using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private string lastLevel = "Level2";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (SceneManager.GetActiveScene().name != "StartMenu" 
                                                 && SceneManager.GetActiveScene().name != "PauseMenu")) 
        {
            PauseGame();
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("Level2");
    }

    public void PauseGame() {
        SceneManager.LoadScene("PauseMenu");
    }

    public void ResumeGame() {
        SceneManager.LoadScene(lastLevel);
    }

    public void QuitGame() {
        SceneManager.LoadScene("StartMenu");
    }
}
