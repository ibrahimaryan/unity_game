using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSwitcher : MonoBehaviour
{
    public GameObject paddleUser;
    public GameObject paddleAI;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("AIEnabled", 0) == 1) {
            paddleUser.SetActive(false);
            paddleAI.SetActive(true);
        } else {
            paddleUser.SetActive(true);
            paddleAI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
