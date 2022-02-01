using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int stickSpeed;
    bool isMoving = true;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isMoving)
            rb.MovePosition(rb.position + Vector2.up * stickSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("MainCircle"))
        {
            transform.SetParent(collision.transform, true);
            isMoving = false;
        }
        if (collision.tag.Equals("Stick"))
        {
            isMoving = false;
            Debug.Log("GAME OVER!");
        }
    }
}
