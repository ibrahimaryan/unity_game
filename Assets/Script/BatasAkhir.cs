using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BatasAkhir : MonoBehaviour
{
    public Text Score;
    public Text HitpointText; // Tambahkan UI Text untuk nyawa

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kayu"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Herbivora") ||
                 other.gameObject.CompareTag("Karnivora") ||
                 other.gameObject.CompareTag("Omnivora"))
        {
            Data.score -= 5;
            Data.hitpoint -= 1;
            Destroy(other.gameObject);

            // Update UI
            Score.text = Data.score.ToString();
            HitpointText.text = Data.hitpoint.ToString();

            // Cek apakah hitpoint habis
            if (Data.hitpoint <= 0)
            {
                gameoverhewan();
            }
        }
    }

    public void gameoverhewan() {
        SceneManager.LoadScene("Game3Gameover");
    }
}