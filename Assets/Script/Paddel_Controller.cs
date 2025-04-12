using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddel_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public float kecepatan;
    public string horizontal;
    public string vertical;
    public float batasAtas;
    public float batasBawah;
    public float batasKanan;
    public float batasKiri;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gerakHorizontal = Input.GetAxis(horizontal) * kecepatan * Time.deltaTime;
        float gerakVertical = Input.GetAxis(vertical) * kecepatan * Time.deltaTime;

        float nextPosHori = transform.position.x + gerakHorizontal;
        float nextPosVer = transform.position.y + gerakVertical;

        if(nextPosHori > batasKanan || nextPosHori < batasKiri) {
            gerakHorizontal = 0;
        }
        if(nextPosVer > batasAtas || nextPosVer < batasBawah) {
            gerakVertical = 0;
        }
        transform.Translate(gerakHorizontal, gerakVertical, 0);
    }
}
