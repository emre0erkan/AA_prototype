using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    MainCircle mainCircle;
    public GameObject mainCircleObject;

    SpawnCircle spawnCircle;
    public GameObject spawnCircleObject;

    private void Awake()
    {
        mainCircle = mainCircleObject.GetComponent<MainCircle>();
        spawnCircle = spawnCircleObject.GetComponent<SpawnCircle>();
    }

    public void GameOver()
    {
        mainCircle.isMoving = false;
        spawnCircle.isOver = true;
    }
}
