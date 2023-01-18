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

    void Start(){
        playerSc = player.GetComponent<PlayerSc>();
        position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        source = player.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            if(!obtained){
                playerSc.SetSpawn(position);
                source.clip = soundEffect;
                source.loop = false;
                source.Play();
                obtained = true;
            }
        } 
    }
}
