using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject obstacle;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    public float startSpawnDelay = 1.5f;
    public float minSpawnDelay = 0.3f;
    public float difficultyIncreaseRate = 0.05f;

    private float currentSpawnDelay;
    private float spawntime;

    void Start()
    {
        currentSpawnDelay = startSpawnDelay;
        spawntime = Time.time;
    }

    void Update()
    {

        currentSpawnDelay -= difficultyIncreaseRate * Time.deltaTime;
        currentSpawnDelay = Mathf.Clamp(currentSpawnDelay, minSpawnDelay, startSpawnDelay);


        if (Time.time > spawntime)
        {
            Spawn();
            spawntime = Time.time + currentSpawnDelay;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(
            obstacle,
            transform.position + new Vector3(randomX, randomY, 0),
            transform.rotation
        );
    }
}