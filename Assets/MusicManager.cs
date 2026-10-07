using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // При старте игры выставляем громкость из памяти
        RefreshVolume();
    }

    public void RefreshVolume()
    {
        if (audioMixer == null) return;
        audioMixer.SetFloat("MusicVol", PlayerPrefs.GetInt("musicButton", 1) == 1 ? 0f : -80f);
        audioMixer.SetFloat("SFXVol", PlayerPrefs.GetInt("sfxButton", 1) == 1 ? 0f : -80f);
    }
}
