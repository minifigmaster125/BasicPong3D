using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool triggerForce = false;
    private bool reset = true;
    private Rigidbody rb;
    private Vector3 initialPos;
    private Quaternion initialRotation;

    public GameObject startText;
    // Start is called before the first frame update
    public GameObject mainCamera;
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
       initialPos = transform.position;
       initialRotation = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        DetectInput();
        

    }

    void DetectInput() {
        if (reset && Input.GetKeyDown(KeyCode.Space)){
            triggerForce = true;
        } 
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Player"){
            Vector3 direction = rb.velocity.normalized;
            float mag = rb.velocity.magnitude;
            Vector3 newDirection = direction + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

            rb.velocity = newDirection.normalized * mag;
            rb.AddForce(newDirection * 0.5f);

            mainCamera.GetComponent<CameraShake>().shakeDuration =  0.2f;
            transform.LookAt(newDirection);
            Debug.DrawRay(transform.position, newDirection, Color.green, 3f);
            Debug.DrawRay(transform.position, transform.up, Color.magenta, 3f);
            Debug.DrawRay(transform.position, transform.forward, Color.blue, 3f);
            GetComponent<ParticleSystem>().Play();
        
        }
        if(col.gameObject.name == "Goal1" || col.gameObject.name == "Goal2"){
            transform.position = initialPos;
            transform.rotation = initialRotation;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            reset = true;
            startText.SetActive(true);
        }
    }

    void FixedUpdate() {
        if (reset && triggerForce){
            rb.AddForce(new Vector3(2,0,0));
            reset = false;
            triggerForce = false;
            startText.SetActive(false);
        }
    }

    public bool isReset(){
        return reset;
    }
}
