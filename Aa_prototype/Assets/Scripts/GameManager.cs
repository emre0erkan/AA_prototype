using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MainCircle mainCircle;
    public GameObject mainCircleObject;

    Movement movement;
    public GameObject MovementObject;

    SpawnCircle spawnCircle;
    public GameObject spawnCircleObject;

    public Animator animator;
    public Text mainCircleText;
    [SerializeField] private Text one;
    [SerializeField] private Text two;
    [SerializeField] private Text three;

    public int stickGoal;
    public bool gameOver = true;
    public bool canShoot = true;


    private void Awake()
    {
        mainCircle = mainCircleObject.GetComponent<MainCircle>();
        spawnCircle = spawnCircleObject.GetComponent<SpawnCircle>();
        movement = MovementObject.GetComponent<Movement>();
    }

    private void Start()
    {
        PlayerPrefs.SetInt("save", (SceneManager.GetActiveScene().buildIndex));
        PlayerPrefs.GetInt("save");
        mainCircleText.text = SceneManager.GetActiveScene().name;

        if (stickGoal < 2)
        {
            one.text = stickGoal + "";
            two.text = "";
            three.text = "";
        }
        else if (stickGoal < 3)
        {
            one.text = stickGoal + "";
            two.text = (stickGoal - 1) + "";
            three.text = "";
        }
        else
        {
            one.text = stickGoal + "";
            two.text = (stickGoal - 1) + "";
            three.text = (stickGoal - 2) + "";
        }
    }
    public void RemainingStickText()
    {
        movement.numberOfStick.text = stickGoal.ToString();
        stickGoal--;
        if (stickGoal < 2)
        {
            one.text = stickGoal + "";
            two.text = "";
            three.text = "";
        }
        else if (stickGoal < 3)
        {
            one.text = stickGoal + "";
            two.text = (stickGoal - 1) + "";
            three.text = "";
        }
        else
        {
            one.text = stickGoal + "";
            two.text = (stickGoal - 1) + "";
            three.text = (stickGoal - 2) + "";
        }
        //if (stickGoal == 0 && gameOver == false)   
        //{
        //    canShoot = false;
        //    NextLevel();
        //}
    }
    public void GameOver()
    {
        StartCoroutine(WaitForGameOver());
    }

    IEnumerator WaitForGameOver()
    {
        gameOver = true;
        animator.SetTrigger("gameovertrigger");
        mainCircle.isMovingCircle = false;
        spawnCircle.isOver = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        StartCoroutine(WaitForNextLevel());
    }

    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(0.3f);
        mainCircle.isMovingCircle = false;
        spawnCircle.isOver = true;
        animator.SetTrigger("nextleveltrigger");
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            PlayerPrefs.SetInt("save", 0);
            SceneManager.LoadScene(0);
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
