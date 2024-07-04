using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
     private HealthController healthController;
    Vector2 velocityVec = new Vector2(0,0);
    Vector2 directionVec = new Vector2(1,1);
    float ballSpeed = 3f;
    
    
    public void SetBallSpeed(float speed,Vector2 dir){
        velocityVec = new Vector2(speed,speed);
        velocityVec = velocityVec * dir;
    }
    private void Start() {
        SetBallSpeed(ballSpeed,directionVec);
        healthController = GameObject.Find("HealthController").GetComponent<HealthController>();
    }
    private void Update() {
        Vector2 currentPos = transform.position;
        currentPos +=velocityVec * Time.deltaTime;
        transform.position = currentPos;
        
        


    }

  

     private void OnCollisionEnter2D(Collision2D other) {

        
        Vector2 normal = new Vector2(0f,0f);
        // Loop through all contact points in the collision
        foreach (ContactPoint2D contact in other.contacts)
        {
            // Access the normal vector of the contact point
            normal = contact.normal;

            
        }
        float dotPro = Vector3.Dot(velocityVec, normal);
        velocityVec = velocityVec - 2*dotPro*normal;


        // updating platforms
        if(other.gameObject.tag == "Platforms"){

            SoundManager.instance.BallHit_With_Platforms();
            Platforms temp = other.gameObject.GetComponent<Platforms>();
            if(temp){
                temp.UpdatePlatform_Details();
            }
            
        }
        

        // updating Health - decreasing
        if(other.gameObject.name.Equals("Bottom")){
            
               GameObject[] Balls = GameObject.FindGameObjectsWithTag("Ball");
               if(Balls.Length>1){
                Destroy(this.gameObject);
               }else{
                int Health = healthController.DecreaseHealth();

               if(Health > 0){
                SetBallSpeed(0,directionVec*0);
                this.gameObject.SetActive(false);
                Invoke("SpawnBall",1f);
               }
               else{
                    Destroy(this.gameObject);
               }
               }
         
        }else if(other.gameObject.tag.Equals("Wall")&&!other.gameObject.name.Equals("Bottom")){
            SoundManager.instance.BallHit_With_Wall();
        }



         
        
    }

    

    public void SpawnBall(){

        SoundManager.instance.PlayerSpawn();
        transform.position = new Vector2(0,-3.95f);
        this.gameObject.SetActive(true);
        
        SetBallSpeed(ballSpeed,directionVec);
    }

}

