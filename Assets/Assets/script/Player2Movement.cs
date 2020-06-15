using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody2D body2d;
    public float Velinit = 0.06f;
    protected float Vel;
    private void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        Vel = Velinit;
    }
    
    private void Update()
    {
        var position = body2d.position;
        
        var multiplier = Vector2.zero;

        if (body2d.position.y > 4 || body2d.position.y < -4)
        {
            var temp = body2d.position.y;
            body2d.position = new Vector2(8, Mathf.Abs(temp) / temp * 4f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            multiplier = new Vector2(0,-1 * Vel);
        } 
        else if(Input.GetKey(KeyCode.W))
        {
            multiplier = new Vector2(0,1 * Vel);
        }

        body2d.position += multiplier;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            var temp = body2d.position.y;
            body2d.position = new Vector2(8, Mathf.Abs(temp) / temp * 4f);

        }
    }
}
