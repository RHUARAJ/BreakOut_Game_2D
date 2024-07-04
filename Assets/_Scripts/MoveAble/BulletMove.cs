using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{   private Vector2 velocityVec;
    // Start is called before the first frame update
    void Start()
    {
        velocityVec = new Vector2(0f,10f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = transform.position;
        currentPos += velocityVec * Time.deltaTime;
        transform.position = currentPos;
    }



    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag.Equals("Platforms")){
           Platforms temp = other.gameObject.GetComponent<Platforms>();
           if(temp){
                temp.UpdatePlatform_Details();
           }
            
            SoundManager.instance.BallHit_With_Platforms();
            Destroy(this.gameObject);
        }else if(other.gameObject.tag.Equals("Wall")){
            SoundManager.instance.BallHit_With_Wall();
            Destroy(this.gameObject);
        }
    }
}
