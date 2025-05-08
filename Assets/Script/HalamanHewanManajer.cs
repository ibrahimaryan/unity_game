using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanHewanManager : MonoBehaviour
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
    public void KembaliKeMenu(){
        SceneManager.LoadScene("MenuGame3");
    }
    public void UlangiGame(){
        Data.score = 0;
        Data.hitpoint = 5;
        SceneManager.LoadScene("Game3");
    }
}
