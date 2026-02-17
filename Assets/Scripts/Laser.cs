using UnityEngine;

public class Laser : MonoBehaviour
{

    public float speed = 20f;
    public float maxdist = 20f;
    public Rigidbody2D rb;
    private Vector2 startpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startpos = transform.position;
        rb.linearVelocity = transform.right * speed;
    }
    void Update()
    {
        float distancetravelled = Vector2.Distance(startpos,transform.position);
        if (distancetravelled > maxdist)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }



}
