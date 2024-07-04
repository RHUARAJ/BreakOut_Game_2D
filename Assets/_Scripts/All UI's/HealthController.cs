using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private  List<GameObject>  Healths = new List<GameObject>();
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject PlayerMove;
    [SerializeField] private UIController uIController;

    private int Health=3;


    private void Start() {
        Health = GameData.HealthS;

        for(int i =0 ; i<Health;i++){
            Healths.Add(InstantiateHealth(healthPrefab));
        }

        
    }

    private GameObject InstantiateHealth(GameObject health_){
            GameObject objUI = Instantiate(health_);
            objUI.transform.SetParent(transform.GetChild(0).gameObject.transform);

            return objUI;
    }

    public int DecreaseHealth(){
        for(int i = 0; i<Healths.Count; i++){
            if(Healths[i].activeSelf){
                Healths[i].SetActive(false);
                Health--;
                GameData.HealthS = Health;
                if(!(Health<=0))
                SoundManager.instance.PlayerDead();
                break;
            }
        }
        // UI gameOver
        if(Health<=0){
            GameData.HealthS = 3;
            uIController.SetGameOverScore(GameData.Score.ToString());
            GameOverPanel.SetActive(true);
            PlayerMove.SetActive(false);
            SoundManager.instance.GameOver();
            

        }
        return Health;
    }

    public int IncreaseHealth(){
        bool isHealthIncreased = false;
        for(int i = 0; i<Healths.Count; i++){
            if(!Healths[i].activeSelf){
                Healths[i].SetActive(true);
                Health++;
                GameData.HealthS = Health;
                isHealthIncreased = true;
                break;
            }
        }

        if(!isHealthIncreased){
                Health++;
                GameData.HealthS = Health;
                Healths.Add(InstantiateHealth(healthPrefab));
        }
        return Health;
    }
}
