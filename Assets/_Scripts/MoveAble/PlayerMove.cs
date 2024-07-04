using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 primePos,Velocity=new Vector2(2f,0f),newVelocity;
     float speed = 7f;
     float limit = 7.625f;

     public float Limit{
        set{
            limit = value;
        }

        get{
            return limit;
        }
     }
    
    public float SetSpeed{
        set{
            speed = value;
        }
        get{
            return speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        float xDirection = Input.GetAxis("Horizontal");
        newVelocity.x = xDirection * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(newVelocity.x, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, -Limit, Limit);
        // 7.625 normal
        // 8.125 short
        // 7.123 large
        transform.position = newPosition;
               
        

        

    }

    // private void FixedUpdate() {
    //     GetComponent<Rigidbody2D>().velocity = newVelocity;
    // }


    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Ball"){
           SoundManager.instance.BallHit_With_Player();
        }
    }
}
