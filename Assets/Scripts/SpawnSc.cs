using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSc : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private PlayerSc playerSc;
    private Vector3 position;
    
    private AudioSource source;

    [SerializeField]
    private AudioClip soundEffect;

    private bool obtained = false;
    
    private Control3Sc control3;

    void Start(){
        playerSc = player.GetComponent<PlayerSc>();
        position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        source = player.GetComponent<AudioSource>();
        control3 = player.GetComponent<Control3Sc>();
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            if(!obtained){
                if(this.gameObject.name == "SpawnPointSpeed"){
                    control3._maxSpeed = 11f;
                }
                playerSc.SetSpawn(position);
                source.clip = soundEffect;
                source.volume = 1f;
                source.loop = false;
                source.Play();
                obtained = true;
            }
        } 
    }
}
