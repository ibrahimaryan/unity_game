using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string enterScene;
    public string escapeScene;
    public bool isEscapeToExit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Name Scene: " + enterScene);
            SceneManager.LoadScene(enterScene);
        }
        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                Debug.Log("Name Scene: " + escapeScene);
                SceneManager.LoadScene(escapeScene);
            }
        }
    }

    public void MulaiPermainan1() {
        SceneManager.LoadScene("MenuGame1");
    }

    public void MulaiPermainan2() {
        SceneManager.LoadScene("MenuGame2");
    }

    public void MulaiPermainan3() {
        SceneManager.LoadScene("MenuGame3");
    }

    public void MulaikeMenuUtama() {
        SceneManager.LoadScene("MenuUtama");
    }

    public void Credits() {
        SceneManager.LoadScene("Pengenalan");
    }

    void KembaliKeMenu() {
        SceneManager.LoadScene("MenuUtama"); // ganti dengan nama scene menu utama kamu
    }
}
