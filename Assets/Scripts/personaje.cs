using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour {

  //  public Camera camera;

    public float rotationspeedX = 2.0f;
    public float rotationspeedY = 2.0f;
    private float rotx = 0.0f;
    private float roty = 0.0f;


    public float speedX;
    public float speedY;
    public float speedZ;
    public bool animationon;
    // Use this for initialization

    //private float zspeed;

    float posx;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        controllers();
	}

    void controllers() {
        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = 0;

        if (Input.GetKey("e")){
            Debug.Log("APRETADA LA E");
         
            moveY = 1.0f ;
        }
        if (Input.GetKey("q")){
            Debug.Log("APRETADA LA Q");
            moveY = -1.0f ;
        }

        rotx += rotationspeedX * Input.GetAxis("Mouse X");
        roty -= rotationspeedY * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(roty, rotx, 0.0f);

        posx += 1f ;
        if (animationon){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
            /*transform.Translate(posx * speedX,
                           0,
                           0);*/
        }
        else{
            transform.Translate(moveX * speedX,
                           moveY * speedY,
                           moveZ * speedZ);
        }

    }
}
