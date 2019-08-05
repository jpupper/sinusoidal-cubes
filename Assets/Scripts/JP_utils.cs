using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JP_utils : MonoBehaviour {


    public static float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
