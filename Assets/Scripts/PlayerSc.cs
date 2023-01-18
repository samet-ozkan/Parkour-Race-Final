using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSc : MonoBehaviour
{
    
    private GameObject game;
    private GameSc gameSc; 
    private Rigidbody rb; 
    public bool onGround;
    public GameObject section2ChangeControl; 
    private Vector3 spawn;
    private bool isFinishedParkour;
    private Transform model;
    private Animator animator;
    
    void Start(){
        isFinishedParkour = false;
        rb = GetComponent<Rigidbody>();
        onGround = false;
        model = this.gameObject.transform.GetChild(2).transform;
        animator = model.GetComponent<Animator>();
        game = GameObject.Find("Game");
        gameSc = game.GetComponent<GameSc>();
    }

    void FixedUpdate(){

        float verticalInput = 0;

        switch(this.gameObject.name){
            case "P1":
                verticalInput = Input.GetAxis("P1Vertical");
                break;
            case "P2":
                verticalInput = Input.GetAxis("P2Vertical");
                break;
            default:
                break;
        }

        if(verticalInput != 0){
            bool b = (verticalInput > 0) ? true : false;
            animator.SetBool("RunForward", b);
            animator.SetBool("RunBackward", !b);
        }
        else{
            animator.SetBool("RunForward", false);
            animator.SetBool("RunBackward", false);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Floor"){
            onGround = true;
            animator.SetBool("OnGround", true);
        }

        if(other.gameObject.tag == "Plane"){
            if(!isFinishedParkour){
                Spawn();
            }
        }
    }

    void OnCollisionStay(Collision other){
        if(!onGround && other.gameObject.tag == "Floor"){
            onGround = true;
            animator.SetBool("OnGround", true);
        }
    }

    void OnCollisionExit(Collision other){
        if(onGround){
            onGround = false;
            animator.SetBool("OnGround", false);
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Trigger girdi: " + other.gameObject.name);
        if(other.gameObject.tag == "Laser"){
            Spawn();
            Control3Sc control3 = this.gameObject.GetComponent<Control3Sc>();
            if(!control3.enabled){
                this.gameObject.GetComponent<Control2Sc>().enabled = false;
                control3.enabled = true;
                control3.InitCamera();
                this.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                section2ChangeControl.SetActive(true);
            }
        }

        if(other.gameObject.name == "P1LastLoop" && gameObject.name == "P1") {
            Debug.Log("P1 last loop.");
            gameSc.P1Win();
        }
        
        else if(other.gameObject.name == "P2LastLoop" && gameObject.name == "P2") {
            Debug.Log("P2 last loop.");
            gameSc.P2Win();
        } 
    }

    public void SetSpawn(Vector3 spawn){
        this.spawn = spawn;
    }

    public void Spawn(){
        this.transform.position = spawn;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
