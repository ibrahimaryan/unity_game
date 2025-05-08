using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HalamanManagerTebakHewan : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEscapeToExit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (isEscapeToExit) {
                Application.Quit();
            } else {
                KembaliKeMenu();
            }
        }
    }

    public void MulaiPermainan() {
        SceneManager.LoadScene("Game3");
    }

    public void MulaiPermainan2() {
        SceneManager.LoadScene("MenuGame2");
    }

    public void MulaiPermainan3() {
        SceneManager.LoadScene("MenuGame3");
    }

    public void Credits() {
        SceneManager.LoadScene("Pengenalan");
    }

    void KembaliKeMenu() {
        SceneManager.LoadScene("MenuUtama"); // ganti dengan nama scene menu utama kamu
    }
}
