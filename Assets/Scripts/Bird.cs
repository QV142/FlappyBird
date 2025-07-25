using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float flapForce = 5f;
    public bool hasStarted = false;
    public bool isGameOver = false;
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        if (isGameOver) return;
        if (!hasStarted)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                hasStarted = true;
                rb.gravityScale = 1f;
                Flap();
            }
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Flap();
            }
        }
    }

    void Flap()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;
        isGameOver = true;
        GameManager.instance.GameOver();
    }
}
