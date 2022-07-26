using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public AudioSource MusicAudio; 
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume")){
            Load();
        }
        else{
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
    }

    public void ChangeVolume(){
        MusicAudio.volume = volumeSlider.value;
        Save();
    }
    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
