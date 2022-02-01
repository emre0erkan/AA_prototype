using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    public GameObject stick;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnStick();
        }
    }

    public void SpawnStick()
    {
        Instantiate(stick, transform.position, Quaternion.identity);
    }
}
