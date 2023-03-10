using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSc : MonoBehaviour
{

    private float speed;
    private Vector3 firstPosition;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(-1f, 1f);
        firstPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        Debug.Log("Square Fixed update girdi");
        Vector3 position = transform.position;
        float scale = Mathf.Abs(firstPosition.x - position.x);
        if(scale > 4f){
            speed *= -1;
        }
        Debug.Log("Speed: " + speed);
        this.transform.Translate(new Vector3(speed, 0f, 0f) * Time.deltaTime);
    }
}
