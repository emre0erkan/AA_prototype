using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircleSpin : MonoBehaviour
{
    public int rotateSpeed;

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
