using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{

    public float speed;
    public int player;
    private string collided;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void OnCollisionEnter(Collision col) {
        string collidedObj = col.gameObject.name;
        if (collidedObj != "ball"){
            collided = col.gameObject.name;
        }
    }
    void OnCollisionExit(Collision col) {
        string collidedObj = col.gameObject.name;
        if (collidedObj != "ball"){
            collided = null;
        }
    }
    void DetectInput() {
        if (player == 1){
            if (Input.GetKey(KeyCode.DownArrow) && collided != "bottomWall"){
                transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
            } 
            if (Input.GetKey(KeyCode.UpArrow) && collided != "topWall"){
                transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            }
        } else if (player == 2){
            if (Input.GetKey(KeyCode.S) && collided != "bottomWall"){
                transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
            } 
            if (Input.GetKey(KeyCode.W) && collided != "topWall"){
                transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            }
            
        }
    }
}
