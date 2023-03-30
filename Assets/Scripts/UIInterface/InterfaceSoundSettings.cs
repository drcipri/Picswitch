using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceSoundSettings : MonoBehaviour
{
    [Header("Volume")]
    [SerializeField] private Slider voiceSoundSlider;
    [SerializeField] private Slider effectsSoundSLider;
    [SerializeField] private Slider generalSoundSlider;
    [Header("Data Objects")]
    [SerializeField] private SoundManagerSO soundManagerSO;

    private void Awake()
    {
        LoadSoundsSettingsVolume();
        SetSliders();
    }
    public void LoadSoundsSettingsVolume()
    {
        if(PlayerPrefs.HasKey("VoiceVolume"))
        {
            soundManagerSO.SetVoiceVolume(PlayerPrefs.GetFloat("VoiceVolume"));
        }
        if(PlayerPrefs.HasKey("EffectsVolume"))
        {
            soundManagerSO.SetEffectsVolume(PlayerPrefs.GetFloat("EffectsVolume"));
        }
        if(PlayerPrefs.HasKey("GeneralVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("GeneralVolume");
        }

       
    }

    public void SaveSoundsSettingsVolume()
    {
        PlayerPrefs.SetFloat("VoiceVolume", voiceSoundSlider.value);
        PlayerPrefs.SetFloat("EffectsVolume", effectsSoundSLider.value);
        PlayerPrefs.SetFloat("GeneralVolume", generalSoundSlider.value);
        LoadSoundsSettingsVolume();
    }

    public void SetSliders()
    {
        voiceSoundSlider.value = soundManagerSO.GetVoiceVolume();
        effectsSoundSLider.value = soundManagerSO.GetEffectsVolume();
        generalSoundSlider.value = AudioListener.volume;
    }

}
