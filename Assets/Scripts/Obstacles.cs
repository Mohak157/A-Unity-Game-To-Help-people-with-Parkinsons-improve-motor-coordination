using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timebtwnspawn;
    private float spawntime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawntime)
        {
            Spawn();
            spawntime = Time.time + timebtwnspawn;
        }
    }
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
