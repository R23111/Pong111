using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float VelInit;
    private float _vel;
    Vector2 Direction;
    private Rigidbody2D body2d;

    private float _max;
    private float _min;
    

    // Start is called before the first frame update
    void Start()
    {
        _vel = VelInit;
        Direction = new Vector2(-1, Random.Range(-1f, 1f));
        body2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            PlacarTracker.GameStarted = true;

        if (PlacarTracker.GameStarted)
            body2d.velocity = Direction * _vel;
        else
            body2d.velocity = Vector2.zero;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var abs = -1 * Mathf.Abs(Direction.y) / Direction.y;
        if (other.gameObject.CompareTag("Wall"))
            Direction.y *= -1;

        if (other.gameObject.CompareTag("PointLineP1"))
            OnScore(2);

        if (other.CompareTag("PointLineP2"))
            OnScore(1);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherbody = other.gameObject.GetComponent<Rigidbody2D>();

        var otherpos = otherbody.position.y;

        var relativePosition = Mathf.Abs(body2d.position.y) -
                               Mathf.Abs(otherbody.position.y);
        float abs;
        if (otherpos > 0)
            abs = Mathf.Abs(relativePosition) / relativePosition;
        else if (otherpos < 0)
            abs = -1 * Mathf.Abs(relativePosition) / relativePosition;
        else
            abs = 1;

        
        relativePosition = Mathf.Abs(relativePosition);

        var newAngle = (float) (relativePosition * Math.PI / 3);


        if (other.gameObject.CompareTag("PlayerBar"))
        {
            Direction.x *= -1;
            Direction.y = Mathf.Tan(newAngle) * abs;
            PlacarTracker.AddIteration();
            _vel += (PlacarTracker.TimesIterated/3f);
        }

        if (other.gameObject.CompareTag("Debug"))
        {
            Direction.x *= -1;
            Direction.y = 0;
        }
    }

    private void OnScore(int player)
    {
        PlacarTracker.AddScore(player);
        PlacarTracker.GameStarted = false;
        PlacarTracker.ResetIterated();
        Debug.Log(PlacarTracker.TimesIterated);
        _vel = VelInit; 
        body2d.position = Vector2.zero;
        Direction = new Vector2(-1, Random.Range(-1f, 1f));
    }
}