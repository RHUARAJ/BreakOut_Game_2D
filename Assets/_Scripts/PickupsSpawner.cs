using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Pickups;
    int index=0;

    private void Start() {
        index = Random.Range(0,Pickups.Length);
    }

    private void OnDestroy()
    {   if(GetComponent<Platforms>().IsTriggered){
            if(Pickups[index])
        Instantiate(Pickups[index],this.transform.position,Quaternion.identity);
    }
        
    }
}
