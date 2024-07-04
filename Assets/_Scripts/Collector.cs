using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    float previousSpeed = 7f;
    
    [SerializeField] private GameObject Normal,Long,Short,Fire;
    [SerializeField] private GameObject BallPrefab,BallSpawnerPos;
    private PlayerMove playerMoveS;

    private void Start() {
        playerMoveS  = GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
       
        

            switch(other.gameObject.tag){
                case "Live":
                GameObject.Find("HealthController").GetComponent<HealthController>()
                .IncreaseHealth();
                break;

                case "Long":
                Normal.SetActive(false);
                Short.SetActive(false);
                Fire.SetActive(false);
                Long.SetActive(true);
                playerMoveS.Limit = 7.123f;
                break;

                case "Short":
                for(int i = 0; i<transform.childCount;i++){
                    GameObject temp = transform.GetChild(i).gameObject;
                    if(temp.activeSelf){
                        temp.SetActive(false);
                    }
                }
                Short.SetActive(true);

                playerMoveS.Limit = 8.125f;
                break;

                case "Fire":
                for(int i = 0 ; i<transform.childCount;i++){
                    if(i!=1){
                        GameObject temp = transform.GetChild(i).gameObject;
                        if(temp.activeSelf){
                            temp.SetActive(false);
                        }
                    }else{
                         transform.GetChild(i).gameObject.SetActive(true);
                        
                    }
                }

                playerMoveS.Limit = 7.625f;

                StartCoroutine(BackToNormal(5f,"Fire"));
                break;

                case "Slow":
                
                float speedSlow = GetComponent<PlayerMove>().SetSpeed;
                if(speedSlow>=previousSpeed)
                GetComponent<PlayerMove>().SetSpeed = speedSlow / 2;

                StartCoroutine(BackToNormal(8f,"Slow"));
                break;

                case "Fast":
                float speedFast = GetComponent<PlayerMove>().SetSpeed;
                if(speedFast<=previousSpeed)
                GetComponent<PlayerMove>().SetSpeed = speedFast * 2;

                StartCoroutine(BackToNormal(8f,"Fast"));

                break;

                case "ThreeBalls":
                        for (int i = 0; i < 3; i++) {
                            GameObject tempBall = Instantiate(BallPrefab, BallSpawnerPos.transform.position, Quaternion.identity);
                            tempBall.transform.localScale = new Vector3(.27f,.27f,.27f);
                            tempBall.name = "Ball";
                            if (i == 0) {
                                tempBall.transform.position = new Vector3(tempBall.transform.position.x, tempBall.transform.position.y, tempBall.transform.position.z);
                                
                                
                            } else if (i == 1) {
                                tempBall.transform.position = new Vector3(tempBall.transform.position.x + .5f, tempBall.transform.position.y+.5f, tempBall.transform.position.z);
                                
                            } else if (i == 2) {
                                tempBall.transform.position = new Vector3(tempBall.transform.position.x - .5f, tempBall.transform.position.y-.5f, tempBall.transform.position.z);
                                
                            }
                    }
                break;
            }
            

        
        

        if(other.gameObject.tag != "Bullet"){
            SoundManager.instance.Pickup();
            Destroy(other.gameObject);
        }
        
    }


    IEnumerator BackToNormal(float t,string Pickup){
        yield return new WaitForSeconds(t);
        if(Pickup.Equals("Slow")||Pickup.Equals("Fast")){
            GetComponent<PlayerMove>().SetSpeed = previousSpeed;
        }else if(Pickup.Equals("Fire")){
            Normal.SetActive(true);
            Short.SetActive(false);
            Fire.SetActive(false);
            Long.SetActive(false);
            playerMoveS.Limit = 7.625f;
        }
        
        

    }
}
