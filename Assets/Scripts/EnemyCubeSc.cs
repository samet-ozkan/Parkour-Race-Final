using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCubeSc : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        //transform.Translate(transform.forward * speed * Time.deltaTime);
        rb.AddForce(transform.parent.transform.forward * speed);
    }

    /*void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            //HP
        }
    }*/

    void OnCollisionEnter(Collision other){
        Debug.Log("Cube collision!");
        if(other.gameObject.tag == "Plane"){
            Destroy(this.gameObject);
        }
    }

}
