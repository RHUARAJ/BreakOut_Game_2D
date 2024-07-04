using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    
    private int ThreeHit = 3,TwoHit = 2;
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private Sprite secondSprite;
    [SerializeField] private bool ThreeHitPlatform,TwoHitPlatform,OneHitPlatform
    ,LivePlatform;
    private bool isTriggered = false;
    public bool IsTriggered{
        get{
            return isTriggered;
        }
    }
    // private LevelCompeletion levelCompeletion;

    // private void Start() {
    //     levelCompeletion = GetComponentInParent<LevelCompeletion>();
    // }
    

    public void UpdatePlatform_Details(){
        isTriggered = true;
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        
        if(ThreeHitPlatform){
            ThreeHit--;
            switch(ThreeHit){
                case 2:
                spriteRenderer.color = Color.green;
                break;
                case 1:
                spriteRenderer.color = Color.blue;
                break;
                case 0:
                Destroy(this.gameObject);
                break;
            }

        }else if(TwoHitPlatform){
            TwoHit--;
            switch(TwoHit){
                case 1:
                spriteRenderer.sprite = secondSprite;
                break;
                case 0:
                Destroy(this.gameObject);
                break;
            }

        }else if(OneHitPlatform){
            Destroy(this.gameObject);
        }else if(LivePlatform){
            if(!collectablePrefab) 
            return;

            GameObject tempObj=Instantiate(collectablePrefab);
            tempObj.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }

       
    }


    void OnDestroy() {
        if(IsTriggered){
        GameObject temp =GameObject.Find("ScoreManager");
        if(temp)
        temp.GetComponent<ScoreManager>().UpdateScore();

        }

    }
}
