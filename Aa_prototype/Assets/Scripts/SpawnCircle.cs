using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    public GameObject stick;
    public bool isOver = false;

    GameManager gameManager;
    public GameObject GameManager;

    private void Awake()
    {
        gameManager = GameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isOver && gameManager.canShoot)
        {
            
            gameManager.RemainingStickText();
            SpawnStick();
        }
    }

    public void SpawnStick()
    {
        Instantiate(stick, transform.position, Quaternion.identity);
    }
}
