using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   [SerializeField] private AudioSource SE_audioSource;
   [SerializeField] private AudioClip start,over,ready,spawn,dead,shoot,pick,hit_1,hit_2,
   hit_3,click;
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   public void GamaStart(){
    SE_audioSource.PlayOneShot(start);
   }
   public void GameOver(){
    SE_audioSource.PlayOneShot(over);
   }
   public void GetReady(){
    SE_audioSource.PlayOneShot(ready);
   }
   public void PlayerSpawn(){
    SE_audioSource.PlayOneShot(spawn);
   }
   public void PlayerDead(){
    SE_audioSource.PlayOneShot(dead);
   }
   public void PlayerShoot(){
    SE_audioSource.PlayOneShot(shoot);
   }
   public void Pickup(){
    SE_audioSource.PlayOneShot(pick);
   }
   public void BallHit_With_Player(){
    SE_audioSource.PlayOneShot(hit_1);
   }
   public void BallHit_With_Wall(){
    SE_audioSource.PlayOneShot(hit_2);
   }
   public void BallHit_With_Platforms(){
    SE_audioSource.PlayOneShot(hit_3);
   }

   public void UI_Click(){
    SE_audioSource.PlayOneShot(click);
   }

}
