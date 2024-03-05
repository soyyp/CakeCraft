using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour {

      //Object variables
      public Transform[] obstaclePrefabs;
      public Transform[] spawnPoints;
      private int SPRangeEnd;
      private int PrefabRangeEnd;
      private Transform spawnPoint;
      private Transform obstacle;
      public GameHandler gameHandler;

      //Timing variables
      public float spawnRangeStart = 0.5f;
      public float spawnRangeEnd = 1.2f;
      private float timeToSpawn;
      private float spawnTimer = 0f;

      void Start() {
            SPRangeEnd = spawnPoints.Length;
            PrefabRangeEnd = obstaclePrefabs.Length;
      }

      void FixedUpdate(){
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);

            spawnTimer += 0.01f;
            if (spawnTimer >= timeToSpawn){
                  spawnObstacle();
                  spawnTimer =0f;
            }
      }

      void spawnObstacle(){
            int SPnum = Random.Range(0, SPRangeEnd);
            int prefabNum = Random.Range(0, PrefabRangeEnd);
            spawnPoint = spawnPoints[SPnum];
            obstacle = obstaclePrefabs[prefabNum];
            if (gameHandler.getTime() > 0) {
                  Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
            }
      }
}