using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Awake()
    {
        // Buat AudioSource dinamis jika belum ada
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void OnClick()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound); // PlayOneShot bisa dipanggil berkali-kali
        }
    }
}