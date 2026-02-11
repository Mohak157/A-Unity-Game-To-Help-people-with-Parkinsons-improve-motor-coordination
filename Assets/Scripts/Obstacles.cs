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

    public float startBPM = 60f;
    public float maxBPM = 90f;
    public float bpmincreaserate = 2f;

    private float currentBPM;
    public AudioSource metronomeaudio;


    void Start()
    {
        currentBPM= startBPM;
        timebtwnspawn = 60f/currentBPM;
        spawntime= Time.time;

    }
 
    void Update()
    {
        currentBPM +=(bpmincreaserate/60f)* Time.deltaTime;
        currentBPM = Mathf.Clamp(currentBPM,startBPM,maxBPM);
        timebtwnspawn = 60f/currentBPM;
        if (Time.time > spawntime)
        {
            Spawn();
            spawntime = Time.time + timebtwnspawn;
        }
    }
    void Spawn()
    {
        if (metronomeaudio!= null){
            metronomeaudio.Play();
        }
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
