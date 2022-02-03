using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int stickSpeed = 20;
    public bool isMoving = true;

    Rigidbody2D rb;
    GameObject gameManager;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void FixedUpdate()
    {
        if (isMoving)
            rb.MovePosition(rb.position + Vector2.up * stickSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("MainCircle"))
            {
                
                transform.SetParent(collision.transform, true);
                isMoving = false;
            }
        if (collision.tag.Equals("Stick"))
            {
            isMoving = false;
            gameManager.GetComponent<GameManager>().GameOver();
            }
    }
}
