using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    public GameObject stick;
    public bool isOver = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isOver)
        {
            SpawnStick();
        }
    }

    public void SpawnStick()
    {
        Instantiate(stick, transform.position, Quaternion.identity);
    }
}
