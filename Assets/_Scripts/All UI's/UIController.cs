using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject Ball,Player,Platforms,GetReadyP,MainMenu;
    [SerializeField] private Text ScoreObj;
    [SerializeField] private Text GameOverScoreObj;
    // [SerializeField] private Text RoundObj;


    private void Start() {

        // SetRound
        int round =int.Parse(SceneManager.GetActiveScene().name);
        round += 1;
        GameObject.Find("RText").GetComponent<Text>().text = "Round "+round+"/3";


        int temp = PlayerPrefs.GetInt("IsPlayAgainHit",0);

        if(temp == 1){
            PlayerPrefs.SetInt("IsPlayAgainHit",0);

            MainMenu.SetActive(false);
            GetReadyP.SetActive(true);
            SoundManager.instance.GetReady();
        }
    }


   public void GetReady(){
    Ball.SetActive(true);
    Player.SetActive(true);
    Platforms.SetActive(true);
    this.gameObject.SetActive(false);
    SoundManager.instance.GamaStart();

   }

   public void Play(){
    transform.GetChild(2).gameObject.SetActive(false);
    transform.GetChild(3).gameObject.SetActive(true);
   }

   public void Quit(){
    Application.Quit();
   }

   public void PlayAgain(){

    GameData.Score = 0;
    PlayerPrefs.SetInt("IsPlayAgainHit",1);
    SceneManager.LoadScene(0);

    
   }


   public void SetScore(string score){
    if(ScoreObj)
    ScoreObj.text = "Score : "+score;
   }
   public void SetGameOverScore(string score){
    if(GameOverScoreObj)
    GameOverScoreObj.text = "Score : "+score;
   }
}
