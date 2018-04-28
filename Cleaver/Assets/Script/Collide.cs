using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{

    public float speed;
    public Rigidbody2D playerRB;

    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        playerRB.velocity = SimCollision(playerRB.velocity, speed, other.transform.rotation);
    }

    Vector2 SimCollision(Vector2 currentSpeed, float speedLimit, Quaternion barRotation)
    {
        //do some math work here...
        //first to find the angle btween the horizontal direction and the direction of the reflected ray 
        //(which i figured out would be (pi/2 - barRotation angle - angel of incidence))
        //second use the angle and the speed limit to calculate correct Vector2

        return Vector2.zero;
    }
}
