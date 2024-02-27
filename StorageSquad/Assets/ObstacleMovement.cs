using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed at which the object will move

    void Update()
    {
        // Move the object down at a constant speed
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
