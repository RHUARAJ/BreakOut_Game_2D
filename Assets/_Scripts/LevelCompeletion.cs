using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompeletion : MonoBehaviour
{
    bool levelCompleted;
    private void Update() {
        if(transform.childCount >0){
            
        }
        else{
                int nextLevel = int.Parse(SceneManager.GetActiveScene().name);
            if(nextLevel<2){
                SceneManager.LoadScene(nextLevel+1);
            }else{
                GameData.HealthS = 3;
                Debug.Log("THANK YOU FOR PLAYING MY GAME!!!");
                SceneManager.LoadScene(0);
            }
            
            
        }
    }
}
