using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    MainCircle mainCircle;
    public GameObject mainCircleObject;

    Movement movement;
    public GameObject MovementObject;

    SpawnCircle spawnCircle;
    public GameObject spawnCircleObject;

    public Animator animator;

    private void Awake()
    {
        mainCircle = mainCircleObject.GetComponent<MainCircle>();
        spawnCircle = spawnCircleObject.GetComponent<SpawnCircle>();
        movement = MovementObject.GetComponent<Movement>();
    }

    private void FixedUpdate()
    {

        NextLevel();
    }

    public void GameOver()
    {

        StartCoroutine(WaitForGameOver());

    }

    IEnumerator WaitForGameOver()
    {
        animator.SetTrigger("gameovertrigger");
        mainCircle.isMoving = false;
        spawnCircle.isOver = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    public void NextLevel()
    {
        if (mainCircle.currentSticks >= 6)
        {
            Debug.Log("Go to Next Level");

            StartCoroutine(WaitForNextLevel());
        }
    }

    IEnumerator WaitForNextLevel()
    {
        animator.SetTrigger("nextleveltrigger");
        mainCircle.isMoving = false;
        spawnCircle.isOver = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);

    }
}
