using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class bgmusic : MonoBehaviour
{
    public static bgmusic instance;

    public List<string> includedScenes;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (includedScenes.Contains(scene.name))
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }
    }
}