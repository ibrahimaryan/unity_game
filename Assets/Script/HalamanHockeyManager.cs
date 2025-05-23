using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanHockeyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEscapeToExit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            if(isEscapeToExit) {
                Application.Quit();
            }
            else {
                KembaliKeMenu();
            }
        }
    }

    public void MainDenganTeman() {
        PlayerPrefs.SetInt("AIEnabled", 0);
        SceneManager.LoadScene("Game2");
    }
    public void MainDenganAI() {
        PlayerPrefs.SetInt("AIEnabled", 1);
        SceneManager.LoadScene("Game2");
    }
    public void KembaliKeMenu(){
        SceneManager.LoadScene("MenuGame2");
    }
    public void UlangiGame(){
        SceneManager.LoadScene("Game2");
    }
}
