using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider volumeSlider;

    public AudioSource AudioAudio;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("AudioVolume")){
            Load();
        }
        else{
            PlayerPrefs.SetFloat("AudioVolume", 1);
        }
    }

    public void ChangeVolume(){
        AudioAudio.volume = volumeSlider.value;
        Save();
    }
    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("AudioVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("AudioVolume", volumeSlider.value);
    }
}
