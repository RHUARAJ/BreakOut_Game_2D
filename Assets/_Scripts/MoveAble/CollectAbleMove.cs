using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAbleMove : MonoBehaviour
{
    private Vector2 velocityVec ;

    private void Start() {
      GameObject temp =GameObject.Find("PowerUps");
      if(temp){
        transform.SetParent(temp.transform);
      }
      velocityVec = new Vector2(0,-1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocityVec*Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("Wall"))
      Destroy(this.gameObject);
    }

    
}
