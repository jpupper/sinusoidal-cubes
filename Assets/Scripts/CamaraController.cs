using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour {


    public float rotationspeedX = 2.0f;
    public float rotationspeedY = 2.0f;

    private float rotx = 0.0f;
    private float roty = 0.0f;


    public GameObject Player;
    private Vector3 offset;
    // Use this for initialization
    void Start(){
        //PARA QUE SIGA AL PERSONAJE : 
        offset = transform.position - Player.transform.position; 
    }

    // Update is called once per frame
    void Update(){

        //ROTACION DE ACUERDO AL MOUSE
        rotx += rotationspeedX * Input.GetAxis("Mouse X");
        roty -= rotationspeedY * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(roty, rotx, 0.0f);

        //PARA QUE SIGA AL PERSONAJE
        transform.position = Player.transform.position + offset;
    }
}
