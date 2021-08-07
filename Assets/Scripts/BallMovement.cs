using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public PolygonCollider2D polygon;
    [HideInInspector] public Vector3 pos { get { return transform.position;}}

    public float speed;
    public GameObject ball;
    AudioSource tapSound;
    public AudioSource golfBall;
    float fadeTime = 1;
    float t = 1;
    float timer = 2f;
    float time;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        time = timer + Time.time;
        rb = GetComponent<Rigidbody2D>();
        polygon = GetComponent<PolygonCollider2D>();
        tapSound = GetComponent<AudioSource>();
        time = 0;
        tapSound.Stop();
        golfBall.Stop();
    }

    private void Update()
    {
        if (rb.IsSleeping())
        {
            t = 1;
        }

        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Instantiate(ball, mousePos, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        golfBallSound();
    }

    public void golfBallSound()
    {
        t -= 0.05f;
        golfBall.volume = t / fadeTime;
        golfBall.Play();
    }
    
    public void Sound()
    {
            tapSound.Play();
    }
    public void Push(Vector2 force)
    {
        rb.AddForce(force * speed, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }


}
