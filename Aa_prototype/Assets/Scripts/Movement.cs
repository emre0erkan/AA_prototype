using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private int stickSpeed = 20;
    public bool isMovingStick = true;
    public Text numberOfStick;

    Rigidbody2D rb;
    GameManager gManager;
    GameObject gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gManager = gameManager.GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (isMovingStick)
            rb.MovePosition(rb.position + Vector2.up * stickSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("MainCircle"))
        {
            transform.SetParent(collision.transform, true);
            isMovingStick = false;
            if (gManager.stickGoal == 0 && !gManager.gameOver)
            {
                gManager.canShoot = false;
                gManager.NextLevel();
            }

        }
        else if (collision.tag.Equals("Stick"))
        {
            isMovingStick = false;
            gameManager.GetComponent<GameManager>().GameOver();
        }

    }
}
