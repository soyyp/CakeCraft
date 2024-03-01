using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDespawner : MonoBehaviour {

      public Transform bottomWall;
      public float distanceToDestroy = 5f;
      public float distCheck;

      void Start(){
            //find the Paddle object by tag, then load its transform into our variable
            bottomWall = GameObject.FindWithTag("BottomWall").GetComponent<Transform>();
      }

      void Update () {
            if (transform.position.y < (bottomWall.position.y - distanceToDestroy)){
                  Destroy(gameObject);
            }
     }
}