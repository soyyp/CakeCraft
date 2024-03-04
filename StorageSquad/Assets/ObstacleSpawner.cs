using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour {

      //Object variables
      public GameObject obstaclePrefab;
      public Transform[] spawnPoints;
      private int rangeEnd;
      private Transform spawnPoint;
      public Text timeText;
      public GameHandler gameHandler;

      //Timing variables
      public float spawnRangeStart = 0.5f;
      public float spawnRangeEnd = 1.2f;
      private float timeToSpawn;
      private float spawnTimer = 0f;

      private int gameTime;
      private float gameTimer = 0f;

      void Start() {
            gameTime = gameHandler.getTime();
            rangeEnd = spawnPoints.Length - 1;
            UpdateTime();
      }

      void FixedUpdate(){
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            spawnTimer += 0.01f;
            if (spawnTimer >= timeToSpawn){
                  spawnObstacle();
                  spawnTimer =0f;
            }
            gameTimer += 0.016f;
            if (gameTimer >= 1f){
                        gameTime -= 1;
                        gameTimer = 0;
                        UpdateTime();
            }
            if (gameTime <= 0){
                        gameTime = 0;
                        SceneManager.LoadScene("GameOver");
            }
      }

      public void hitPenalty() {
            if (gameTimer >= 1f){
                  gameTime -= 5;
                  gameTimer = 0;
                  UpdateTime();
            }
      }

      public void UpdateTime(){
            timeText.text = "Time: " + gameTime;
      }

      void spawnObstacle(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPoints[SPnum];
            if (gameTime > 0){
                  Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
            }
      }
}