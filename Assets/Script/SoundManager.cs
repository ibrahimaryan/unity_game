using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;  // Biar bisa diakses dari mana saja
    public AudioClip buttonClick;        // Assign file suara di Inspector

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Bertahan saat ganti scene
        }
        else
        {
            Destroy(gameObject);  // Hancurkan duplikat
        }
    }

    // Fungsi untuk play sound
    public void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}