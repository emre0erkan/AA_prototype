using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public int rotateSpeed;
    public int goal = 6;
    public int currentSticks = 0;
    public bool isMovingCircle = true;

    void Update()
    {
        if(isMovingCircle)
        transform.Rotate(0, 0, -rotateSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stick")
        {
            currentSticks++;
        }
    }
}
