using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infiniteTunel : MonoBehaviour {

    public GameObject spawner;
    public float destroyDist;
    public float offsetz;

    private List<GameObject> spawners = new List<GameObject>();
    private Transform playerTransform;


    /*********************************************************/
    //INIT SPAWNER VALUES: 
    private Color col1;
    private Color col2;
    private float freqcolor;
    // public int animationType = 1;
    private int cnt;
    //MOVIMIENTO: 
    private Vector3 T_amp = new Vector3(2, 2, 0);
    private Vector3 T_speed;
    private Vector3 T_freq;
    //SCALE 
    //public Vector3 S_amp;
    private Vector3 S_speed;
    private Vector3 S_freq;
    private Vector3 S_maxsize;
    private Vector3 S_minsize;


    /**************************************************************/

    public float PNspeed;
    float PNpos;
    //El perlin noise correspondiente a cada variable.
    private Vector3 PNcol1;
    private Vector3 PNcol2;

    private float PNfreqcolor;
    private float PNcnt;

    private Vector3 PNT_amp;
    private Vector3 PNT_speed;
    private Vector3 PNT_freq;


     //public Vector3 S_amp;
    private Vector3 PNS_speed;
    private Vector3 PNS_freq;
    private Vector3 PNS_maxsize;
    private Vector3 PNS_minsize;


    void Start(){
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //int cnt = 100;
        transform.Rotate(90, 0, 0);
        initPerlinSeeds();
    }

    void Update(){
        
        spawnSpawners();
        destroySpawners();
        updatePerlinNoiseValues();
        //Debug.Log("CNT: "+spawners.Count);
    }

    void initPerlinSeeds(){
        PNcol1 = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
        PNcol2 = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
        PNfreqcolor = Random.Range(0, 1000);
        PNcnt = Random.Range(0, 1000);
        PNT_amp = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
        PNT_speed = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
        PNT_freq = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
        PNS_speed = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
        PNS_freq = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
        PNS_maxsize = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
        PNS_minsize = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
    }

    void updatePerlinNoiseValues(){
        PNpos += PNspeed;
        //Debug.Log(PNpos);
        //INIT SPAWNER VALUES: 
        float colmult = 2;
        col1 = new Color(Mathf.PerlinNoise(PNcol1.x+ PNpos, PNcol1.x+ PNpos)* colmult,
            Mathf.PerlinNoise(PNcol1.y+ PNpos, PNcol1.y+ PNpos)* colmult,
            Mathf.PerlinNoise(PNcol1.z+ PNpos, PNcol1.z+ PNpos)* colmult);

        col2 = new Color(Mathf.PerlinNoise(PNcol2.x+ PNpos, PNcol2.x+ PNpos)* colmult, 
            Mathf.PerlinNoise(PNcol2.y+ PNpos, PNcol2.y+ PNpos)* colmult, 
            Mathf.PerlinNoise(PNcol2.z+ PNpos, PNcol2.z+ PNpos)* colmult);

        float ampmult = 4;
        float sum = 1;
        T_amp = new Vector3(Mathf.PerlinNoise(PNT_amp.x + PNpos, PNT_amp.x + PNpos) * ampmult + sum,
                            Mathf.PerlinNoise(PNT_amp.x + PNpos, PNT_amp.x + PNpos) * ampmult + sum, 
                            0);


       





        float T_speed_multiplier = 10;
        float T_speed_sum = -5;
        T_speed = new Vector3(Mathf.PerlinNoise(PNT_speed.x + PNpos, PNT_speed.x + PNpos) * T_speed_multiplier + T_speed_sum,
                                Mathf.PerlinNoise(PNT_speed.y + PNpos, PNT_speed.y + PNpos) * T_speed_multiplier + T_speed_sum,
                                Mathf.PerlinNoise(PNT_speed.z + PNpos, PNT_speed.z + PNpos) * T_speed_multiplier + T_speed_sum);



        float S_speed_multiplier = 10;
        float S_speed_sum = 0;
        S_speed = new Vector3(Mathf.PerlinNoise(PNS_speed.x + PNpos, PNS_speed.x + PNpos) * S_speed_multiplier + S_speed_sum,
                                Mathf.PerlinNoise(PNS_speed.y + PNpos, PNS_speed.y + PNpos) * S_speed_multiplier + S_speed_sum,
                                Mathf.PerlinNoise(PNS_speed.z + PNpos, PNS_speed.z + PNpos) * S_speed_multiplier + S_speed_sum);


        float S_freq_multiplier = 3;
        float S_freq_sum = 0;
        S_freq = new Vector3(Mathf.PerlinNoise(PNS_freq.x + PNpos, PNS_freq.x + PNpos) * S_freq_multiplier + S_freq_sum,
                               Mathf.PerlinNoise(PNS_freq.y + PNpos, PNS_freq.y + PNpos) * S_freq_multiplier + S_freq_sum,
                               Mathf.PerlinNoise(PNS_freq.z + PNpos, PNS_freq.z + PNpos) * S_freq_multiplier + S_freq_sum);

        float S_maxsize_multiplier = 0.5f;
        float S_maxsize_sum = 0;
        S_maxsize = new Vector3(Mathf.PerlinNoise(PNS_maxsize.x + PNpos, PNS_maxsize.x + PNpos) * S_maxsize_multiplier + S_maxsize_sum,
                                  Mathf.PerlinNoise(PNS_maxsize.y + PNpos, PNS_maxsize.y + PNpos) * S_maxsize_multiplier + S_maxsize_sum,
                                  Mathf.PerlinNoise(PNS_maxsize.z + PNpos, PNS_maxsize.z + PNpos) * S_maxsize_multiplier + S_maxsize_sum);


        float S_minsize_multiplier = 0.5f;
        float S_minsize_sum = 0;
        S_minsize = new Vector3(Mathf.PerlinNoise(PNT_amp.x + PNpos, PNT_amp.x + PNpos) * S_minsize_multiplier + S_minsize_sum,
                                  Mathf.PerlinNoise(PNT_amp.y + PNpos, PNT_amp.y + PNpos) * S_minsize_multiplier + S_minsize_sum,
                                  Mathf.PerlinNoise(PNT_amp.z + PNpos, PNT_amp.z + PNpos) * S_minsize_multiplier + S_minsize_sum);
        /* freqcolor;
         // public int animationType = 1;
         cnt;
         //MOVIMIENTO: 
         T_amp = new Vector3(2, 2, 0);
         T_speed;
         T_freq;
         //SCALE 
         //public Vector3 S_amp;
         S_speed;
         S_freq;
         S_maxsize;
         S_minsize;*/


    }
    void spawnSpawners(){

        GameObject aux = Instantiate(spawner, transform.position, transform.rotation);
        spawner myscript = aux.GetComponent<spawner>();
        myscript.transform.localPosition = new Vector3(transform.position.x, 
            transform.position.y , 
            playerTransform.position.z+transform.position.z+offsetz);
        myscript.cnt = 10 ;
       
        myscript.col1 = col1;
        myscript.col2 = col2;

        myscript.freqcolor = 4;
        myscript.T_amp = T_amp;
        myscript.T_freq = new Vector3(2, 2, 2);
        myscript.T_speed = new Vector3(4, 4, 2);
        myscript.S_speed = S_speed;
        myscript.S_freq = S_freq;
        myscript.S_minsize = S_minsize;
        myscript.S_maxsize = S_maxsize;
        myscript.life = 500;
        spawners.Add(aux);
        aux.transform.parent = transform;

        
    }

    void destroySpawners(){
        for (int i = 0; i < spawners.Count; i++){
            float dist = Vector3.Distance(playerTransform.localPosition, spawners[i].transform.localPosition);


            spawner aux = spawners[i].GetComponent<spawner>();
            if (aux.life < 1){
                Destroy(spawners[i]);
                spawners.Remove(spawners[i]);
            }
        }

    }

}
