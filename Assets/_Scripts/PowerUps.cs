using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private void CleaningGameObject_Those_WereCreated_OnDestroy(){
        
            for(int i =0; i<transform.childCount;i++){
                Destroy(transform.GetChild(i).gameObject);
            }
    }


    void Start(){
        CleaningGameObject_Those_WereCreated_OnDestroy();
    }


    void OnDestroy() {
        CleaningGameObject_Those_WereCreated_OnDestroy();
    }



}
