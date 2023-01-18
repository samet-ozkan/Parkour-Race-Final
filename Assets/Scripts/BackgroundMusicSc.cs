using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicSc : MonoBehaviour
{

    public static BackgroundMusicSc instance = null;

    [SerializeField]
    private AudioClip music;

    private AudioSource source;

     void Awake(){

        if(instance != null){
            Destroy(this.gameObject);
        }
        else{
            instance = this;
            source = this.gameObject.GetComponent<AudioSource>();
            if(music != null){
                source.clip = music;
                source.volume = 0.8f;
                source.loop = true;
                source.Play();
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }

}
