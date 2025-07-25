using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float spriteWidth = 7.5f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x <= startPosition.x - spriteWidth)
        {
            transform.position = new Vector3(startPosition.x, transform.position.y, transform.position.z);
        }
    }
}
