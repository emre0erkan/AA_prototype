using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int stickSpeed = 20;
    public bool isMovingStick = true;
    public bool gameOver = false;

    Rigidbody2D rb;
    GameObject gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

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
        }
        if (collision.tag.Equals("Stick"))
        {
            isMovingStick = false;
            gameOver = true;
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
