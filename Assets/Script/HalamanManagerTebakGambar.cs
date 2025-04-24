using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManagerTebakGambar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetTebak() {
        SceneManager.LoadScene("Game1_tebak");
    }
    public void KeluarTebak(){
        SceneManager.LoadScene("MenuGame1");
    }

    public void PengenalanAlatMusik(){
        SceneManager.LoadScene("Game1");
    }
}
