using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner : MonoBehaviour {


    public Color col1;
    public Color col2;
    public float freqcolor;


   // public int animationType = 1;
    public int cnt;

    //MOVIMIENTO: 
    public Vector3 T_amp = new Vector3(2, 2, 0);
    public Vector3 T_speed;
    public Vector3 T_freq;

    //SCALE 
    //public Vector3 S_amp;
    public Vector3 S_speed;
    public Vector3 S_freq;

    public Vector3 S_maxsize;
    public Vector3 S_minsize;
    public float life;
    //public float minsize;
    //public float maxsize;
    //public float freq;

    public GameObject spawnee;

    private List <GameObject> cubos = new List<GameObject>();

    void Start () {
        //life = 1000;
        for (int i = 0; i <cnt; i++) {

            float ax = map(i, 0, cnt - 1, 0, Mathf.PI * T_freq.x);
            float ay = map(i, 0, cnt - 1, 0, Mathf.PI * T_freq.y);
            float az = map(i, 0, cnt - 1, 0, Mathf.PI * T_freq.z);
            float acolor = map(i, 0, cnt - 1, 0, Mathf.PI * 2 * freqcolor);

            //float index = map(i, 0, cnt - 1, 0, 1.0f);
            float x = transform.position.x + Mathf.Sin(ax) * T_amp.x;
            float z = transform.position.z + Mathf.Cos(ay) * T_amp.y;
            float y = transform.position.y + Mathf.Sin(az) * T_amp.z;

            Vector3 initpos = new Vector3(x, z, y);
            GameObject aux = Instantiate(spawnee, initpos, transform.rotation);

            aux.transform.parent = transform;

            float colindex = Mathf.Sin(acolor) * 0.5f + 0.5f;
            Material mat = new Material(Shader.Find("Specular"));


            Color colf = Color.Lerp(col1, col2, colindex);
          
            mat.SetColor("_Color", colf);

            Renderer rend = aux.GetComponent<Renderer>();
            rend.material = mat;

            cubos.Add(aux);
        }

    }
    void changeMaterial(GameObject gameObject, Color col){


    }
    // Update is called once per frame
    void Update(){
        life--;
         //if (animationType == 3){
            for (int i = 0; i < cnt; i++){
                //POSITION
                //float a = map(i, 0, cnt, 0, Mathf.PI * 2);

                float ax = map(i, 0, cnt - 1, 0, Mathf.PI * T_freq.x);
                float ay = map(i, 0, cnt - 1, 0, Mathf.PI * T_freq.y);
                float az = map(i, 0, cnt - 1, 0, Mathf.PI * T_freq.z);

                float x = Mathf.Sin(Time.frameCount * 0.003f * T_speed.x + ax) * T_amp.x;
                float z = Mathf.Cos(Time.frameCount * 0.003f * T_speed.y + ay) * T_amp.y;
                float y = Mathf.Sin(Time.frameCount * 0.003f * T_speed.z + az) * T_amp.z;

                //SCALE

                float sc_ax = map(i, 0, cnt - 1, 0, Mathf.PI * S_freq.x);
                float sc_ay = map(i, 0, cnt - 1, 0, Mathf.PI * S_freq.y);
                float sc_az = map(i, 0, cnt - 1, 0, Mathf.PI * S_freq.z);

                float scx = Mathf.Sin(Time.frameCount * 0.003f * S_speed.x + sc_ax) * S_maxsize.x + S_maxsize.x + S_minsize.x;
                float scy = Mathf.Sin(Time.frameCount * 0.003f * S_speed.y + sc_ay) * S_maxsize.y + S_maxsize.y + S_minsize.y;
                float scz = Mathf.Sin(Time.frameCount * 0.003f * S_speed.z + sc_az) * S_maxsize.z + S_maxsize.z + S_minsize.z;

                Vector3 pos = new Vector3(x, y, z);
                Vector3 sc = new Vector3(scx, scy, scz);

                cubos[i].transform.localPosition = pos;
                cubos[i].transform.LookAt(transform.position);
                cubos[i].transform.localScale = sc;
                
            }
        //}
    }
    float map(float s, float a1, float a2, float b1, float b2){
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}

