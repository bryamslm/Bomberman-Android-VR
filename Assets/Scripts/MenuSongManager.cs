using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuSongManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("menuVolume")){
            PlayerPrefs.SetFloat("menuVolume", 1f);
            Load();
        }else{
            Load();
        }

    }

    public void ChangeVolume(){
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("menuVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("menuVolume", volumeSlider.value);
    }

}
