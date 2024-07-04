using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource BG_audioSource;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        BG_audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(i>2){
            i=0;
        }
        if(!BG_audioSource.isPlaying){
            BG_audioSource.clip = clips[i];
            BG_audioSource.Play();
            i++;
        }
    }
}
