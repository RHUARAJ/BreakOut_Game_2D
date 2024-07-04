using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private UIController uIController;

    private void Start() {
        uIController.SetScore(GameData.Score.ToString());
    }
    public void UpdateScore(){
        GameData.Score += 10;

        uIController.SetScore(GameData.Score.ToString());



    }




}
