using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMoviment : MonoBehaviour
{
    private Rigidbody2D body2d;
    private Rigidbody2D ballBody;
    public float VelInit = 0.06f;
    private float Vel;
    public GameObject ball;
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        ballBody = ball.GetComponent<Rigidbody2D>();
        Vel = VelInit;
    }

    void Update()
    {
        var posDif = ballBody.position.y - body2d.position.y;
        
        Debug.Log(posDif);
        
        var position = body2d.position;
        
        var multiplier = Vector2.zero;

        if (body2d.position.y > 4 || body2d.position.y < -4)
        {
            var temp = body2d.position.y;
            body2d.position = new Vector2(8, Mathf.Abs(temp) / temp * 4f);
        }
        if (posDif < -0.5)
        {
            multiplier = new Vector2(0,-1 * Vel);
        } 
        else if(posDif > 0.5)
        {
            multiplier = new Vector2(0,1 * Vel);
        }

        body2d.position += multiplier;
    }
}
