using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnerx2 : MonoBehaviour
{

    public GameObject spawner;
    
    private List<GameObject> spawners = new List<GameObject>();
    void Start(){


        
        int cnt = 100;
        for (int i = 0; i < cnt; i++){
            GameObject aux = Instantiate(spawner, transform.position, transform.rotation);
            
            spawner myscript = aux.GetComponent<spawner>();

            float y = JP_utils.map(i, 0, cnt, 0, 500);
            float amp = JP_utils.map(i, 0, cnt, 2, 0);
            float r = JP_utils.map(i, 0, cnt, 0, 1);
            float b = JP_utils.map(i, 0, cnt, 1, 0);
            float index = JP_utils.map(i, 0, cnt, 1, 0);
          
            myscript.transform.position = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);
            //myscript.y = y;
            myscript.cnt = 10;

            myscript.col1 = new Color(index, 1.0f -index, 0.5f);
            myscript.col2 = new Color(index, 1.0f -index, index);


            myscript.freqcolor = 4;
            myscript.T_amp = new Vector3(2, 2, 0);
            myscript.T_freq = new Vector3(2, 2, 2);
            myscript.T_speed = new Vector3(4, 4, 2);
            myscript.S_speed = new Vector3(2, 2, 2);
            myscript.S_freq = new Vector3(4, 4, 4);
            myscript.S_minsize = new Vector3(0.4f, 0.4f, 0.4f);
            myscript.S_maxsize = new Vector3(0.2f, 0.2f, 0.2f);

            spawners.Add(aux);

            aux.transform.parent = transform;
        }
        transform.Rotate(90, 0, 0);
    }

    void Update(){
      

    } 
}

