using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 pos;
    public float speed = 1f;
    float mouseSpeed;
    Vector3 oldPosition;
    float timer = 0f;
    float totalDistance = 0f;
    public float duration = 10f;  // 10 seconds timer

    // Update is called once per frame
    void Update()
    {
        pos = Input.mousePosition;
        pos.z = speed;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

        // Increment the timer
        timer += Time.deltaTime;

        // Check if the timer has reached the duration
        if (timer >= duration)
        {
            // Calculate the average speed
            float averageSpeed = totalDistance / duration;
            Debug.Log("Average Speed: " + averageSpeed.ToString("F2"));

            // Reset the timer and total distance for the next round
            timer = 0f;
            totalDistance = 0f;
        }
    }

    void FixedUpdate()
    {
        mouseSpeed = Vector3.Distance(oldPosition, transform.position);
        totalDistance += mouseSpeed;
        oldPosition = transform.position;

        //Debug.Log("Speed: " + mouseSpeed.ToString("F2"));
    }
}
