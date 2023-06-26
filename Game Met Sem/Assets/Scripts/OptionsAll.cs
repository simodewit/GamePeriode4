using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsAll : MonoBehaviour
{
    public Slider volumeSlider;
    public TMP_Dropdown resolutions;
    public Toggle fullscreen;

    public ResolutionList[] res;

    public void Start()
    {
        DontDestroyOnLoad(this);
        OnClickApplyButton();
    }

    public void Update()
    {
        OptionsManager();
    }


    public void OptionsManager()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void OnClickApplyButton()
    {
        Screen.SetResolution(res[resolutions.value].width, res[resolutions.value].height, fullscreen.isOn);
    }
}

[System.Serializable]
public class ResolutionList
{
    public int width;
    public int height;
}
