using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Toggle vsync;
    public Dropdown resolutionDropdown;

    public AudioSource musicSource;
    public Slider musicVolume;
    public Slider sfxVolume;

    public Button resetRecordsButton;
    public Button applyButton;

    public Resolution[] resolution;
    public GameSettings gameSettings;

    void OnEnable(){
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate {OnFullscreenToggle();});
        vsync.onValueChanged.AddListener(delegate {OnVsyncToggle();});
        resolutionDropdown.onValueChanged.AddListener(delegate {OnResolutionChange();});
        musicVolume.onValueChanged.AddListener(delegate {OnMusicVolumeChange();});
        sfxVolume.onValueChanged.AddListener(delegate {OnSfxVolumeChange();});
        applyButton.onClick.AddListener(delegate {SaveAndApply();});
        resetRecordsButton.onClick.AddListener(delegate {resetRecords();});


        resolution = Screen.resolutions;
        foreach(Resolution resolution in resolution){
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void resetRecords(){
        PlayerPrefs.DeleteAll();
    }

    public void OnFullscreenToggle(){
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnVsyncToggle(){
        QualitySettings.vSyncCount = gameSettings.vsync ? 1 : 0;
    }

    public void OnResolutionChange(){
        Screen.SetResolution(resolution[resolutionDropdown.value].width, resolution[resolutionDropdown.value].height, Screen.fullScreen);
    }

    public void OnMusicVolumeChange(){
        musicSource.volume = gameSettings.musicVolume = musicVolume.value;
        gameSettings.musicVolume = musicVolume.value;
    }

    public void OnSfxVolumeChange(){
        gameSettings.sfxVolume = sfxVolume.value;
    }

    public void SaveAndApply(){
        SaveSettings();
        OnFullscreenToggle();
        OnVsyncToggle();
        OnResolutionChange();
        OnMusicVolumeChange();
        OnSfxVolumeChange();
    }

    public void SaveSettings(){
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
        Debug.Log(jsonData);
    }

    public void LoadSettings(){
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        
        fullscreenToggle.isOn = gameSettings.fullscreen;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        vsync.isOn = gameSettings.vsync;
        musicVolume.value = gameSettings.musicVolume;
        sfxVolume.value = gameSettings.sfxVolume;

    }
}
