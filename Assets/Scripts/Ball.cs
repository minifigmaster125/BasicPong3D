using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool firstTime = true;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Player"){
            rb.AddForce(rb.velocity.normalized * 0.5f);
        }
    }

    void FixedUpdate() {
        if (firstTime){
            Debug.Log("addingForce");
            rb.AddForce(new Vector3(2,2,0));
            firstTime = false;
        }
    }
}
