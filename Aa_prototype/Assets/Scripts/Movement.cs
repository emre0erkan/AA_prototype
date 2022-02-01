using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int stickSpeed;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveStick();
    }

    public void MoveStick()
    {
            rb.velocity = new Vector2(0, stickSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("MainCircle"))
        {
            rb.velocity = new Vector2(0, 0);
            transform.SetParent(collision.transform);
        }
        if (collision.gameObject.tag.Equals("Stick"))
        {
            Debug.Log("Game Over!");
        }
    }
}
