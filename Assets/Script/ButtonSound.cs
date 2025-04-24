using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ButtonSound : MonoBehaviour
{
    public AudioClip soundClip;

    private AudioSource audioSource;
    private Button button;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        button = GetComponent<Button>();

        if (button != null)
        {
            // Kalau ini UI Button, daftarkan ke onClick
            button.onClick.AddListener(PlaySound);
        }
    }

    public void PlaySound()
    {
        if (soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning("AudioClip belum di-assign di " + gameObject.name);
        }
    }

    // Untuk non-UI (misalnya: kartu di-click pakai OnMouseDown)
    private void OnMouseDown()
    {
        if (button == null) // Hanya jalan kalau bukan UI Button
        {
            PlaySound();
        }
    }
}
