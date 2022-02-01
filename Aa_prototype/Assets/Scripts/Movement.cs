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

    void Update()
    {
        MoveStick();
    }

    public void MoveStick()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector2(0, 10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("MainCircle"))
        {
            Debug.Log("?");
            rb.velocity = new Vector2(0,0);
        }
        //if (other.tag.Equals("Stick"))
        //{
        //    Debug.Log("Game Over!");
        //}
    }
}
