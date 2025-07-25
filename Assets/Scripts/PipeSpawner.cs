using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float minY = -7f, maxY = -2f;

    private float timer = 0f;
    private Bird bird;

    void Start()
    {
        bird = FindObjectOfType<Bird>();
    }

    void Update()
    {
        if (bird != null && bird.hasStarted)
        {
            timer += Time.deltaTime;
            if (timer >= spawnRate)
            {
                SpawnPipe();
                timer = 0f;
            }
        }
    }

    void SpawnPipe()
    {
        float y = Random.Range(minY, maxY);
        Instantiate(pipePrefab, new Vector3(3f, y, 0f), Quaternion.identity);
    }
}
