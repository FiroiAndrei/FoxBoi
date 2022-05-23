using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private AudioSource BgMusic;
    public GameObject ObjectMusic;
    public Slider volumeSlider;
    private float musicVolume = 0.1f;

    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        BgMusic = ObjectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");
        BgMusic.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        BgMusic.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

}
