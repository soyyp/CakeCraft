using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

      //Object variables
      public GameObject obstaclePrefab;
      public Transform spawnPoint1;
      public Transform spawnPoint2;
      public Transform spawnPoint3;
      private Transform spawnPoint;

      //Timing variables
      public float spawnRangeStart = 0.5f;
      public float spawnRangeEnd = 1.2f;
      private float timeToSpawn;
      private float spawnTimer = 0f;

      void FixedUpdate(){
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            spawnTimer += 0.01f;
            if (spawnTimer >= timeToSpawn){
                  spawnObstacle();
                  spawnTimer =0f;
            }
      }

      void spawnObstacle(){
            int SPnum = Random.Range(1, 4);
            if (SPnum == 1){ spawnPoint = spawnPoint1;}
            else if (SPnum == 2){ spawnPoint = spawnPoint2;}
            else if (SPnum == 3){ spawnPoint = spawnPoint3;}
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
      }
}