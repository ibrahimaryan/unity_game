using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TampilKayu : MonoBehaviour
{
    // Start is called before the first frame update
    public float jeda = 0.8f;
    float timer;
    public GameObject[] obyekKayu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>jeda)
        {
            int random = Random.Range(0, obyekKayu.Length);
            Instantiate (obyekKayu[random], transform.position,transform.rotation);
            timer=0;
        }
    }
}
