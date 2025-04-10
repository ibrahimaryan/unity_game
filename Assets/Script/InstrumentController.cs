using System.Collections;
using UnityEngine;

public class InstrumentController : MonoBehaviour
{
    public GameObject[] instruments;
    public AudioSource[] audioSources;

    private int currentIndex = 0;
    public float fadeDuration = 0.5f;

    void Start()
    {
        ShowOnlyCurrentInstrument();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentIndex < instruments.Length - 1)
        {
            StartCoroutine(SwitchInstrument(currentIndex, currentIndex + 1));
            currentIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex > 0)
        {
            StartCoroutine(SwitchInstrument(currentIndex, currentIndex - 1));
            currentIndex--;
        }
    }

    IEnumerator SwitchInstrument(int fromIndex, int toIndex)
    {
        instruments[fromIndex].SetActive(false);
        instruments[toIndex].SetActive(true);

        // Fade out audio lama
        if (audioSources[fromIndex] != null)
        {
            StartCoroutine(FadeOutAudio(audioSources[fromIndex]));
        }

        // Fade in audio baru
        if (audioSources[toIndex] != null)
        {
            audioSources[toIndex].volume = 0f;
            audioSources[toIndex].Play();
            StartCoroutine(FadeInAudio(audioSources[toIndex]));
        }

        yield return null;
    }

    void ShowOnlyCurrentInstrument()
    {
        for (int i = 0; i < instruments.Length; i++)
        {
            instruments[i].SetActive(i == currentIndex);
            if (audioSources != null && audioSources.Length > i)
            {
                if (i == currentIndex)
                {
                    audioSources[i].volume = 1f;
                    audioSources[i].Play();
                }
                else
                {
                    audioSources[i].Stop();
                }
            }
        }
    }

    IEnumerator FadeOutAudio(AudioSource audio)
    {
        float startVolume = audio.volume;
        float t = 0f;
        while (t < fadeDuration)
        {
            audio.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        audio.volume = 0f;
        audio.Stop();
    }

    IEnumerator FadeInAudio(AudioSource audio)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            audio.volume = Mathf.Lerp(0f, 1f, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        audio.volume = 1f;
    }
}