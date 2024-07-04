using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform LeftGun,RightGun;
    [SerializeField] private GameObject BulletPrefab;
    float shootInterval = 1f;
    void OnEnable()
    {
        RightGun = transform.GetChild(0).gameObject.transform;
        LeftGun = transform.GetChild(1).gameObject.transform;

        StartCoroutine(ShootInterval());
    }

    private void OnDisable() {
        StopCoroutine(ShootInterval());
    }

    IEnumerator ShootInterval(){

        while(true){
            Shoot();
        yield return new WaitForSeconds(shootInterval);
        }
    }


    private void Shoot(){
        SoundManager.instance.PlayerShoot();
        Instantiate(BulletPrefab,RightGun.position,Quaternion.identity);
        Instantiate(BulletPrefab,LeftGun.position,Quaternion.identity);
    }
}
