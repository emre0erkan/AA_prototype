using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public int rotateSpeed;
    public bool isMovingCircle = true;

    void Update()
    {
        if(isMovingCircle)
        transform.Rotate(0, 0, -rotateSpeed*Time.deltaTime);
    }
}
