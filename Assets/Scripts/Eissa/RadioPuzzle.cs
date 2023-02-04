using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RadioPuzzle : MonoBehaviour
{
    [SerializeField] Button increase;
    [SerializeField] Button Decrease;
    [SerializeField] Slider slider;
    [SerializeField] PlayerMovement playerRef;
    //[SerializeField] AudioClip staticSound,theSong;
    float slowlyIncreasedValue = 0.01f;
    bool PlayMusic = false;
    bool isSolved = false;
    void playMuisc()
    {
        if (PlayMusic)
        {
            if (isSolved)
            {
                // call the audio manager here to play the song 
            }
            else
            {
                // call the audio manager here to play the static noise
            }
        }
    }
    private void onWin()
    {
        //call here the dialogue function and the inventory function
    }
    private void OnEnable()
    {
        playerRef.DisableMovement();
    }
    private void OnDisable()
    {
        playerRef.EnableMovement();
    }
    //public void onCloseingThePuzzle()
    //{
    //    playerRef.EnableMovement();
    //}

    private void Update()
    {
        if (!isSolved)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                increaseFrequency();
                slowlyIncreasedValue += (slowlyIncreasedValue * Time.deltaTime);
            }

            //else if (Input.GetKeyDown(KeyCode.RightArrow))
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                slowlyIncreasedValue = 0.01f;
                checkSloution();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                slowlyIncreasedValue += (slowlyIncreasedValue * Time.deltaTime);
                decreaseFrequency();

            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {

                slowlyIncreasedValue = 0.01f;
                checkSloution();
            }
        }
    }
    public void increaseFrequency()
    {
        if (slider.value <= 308)
        {
             slider.value += slowlyIncreasedValue/1.7f;
        }
    }
    public void decreaseFrequency()
    {
        if (slider.value >= 87.5)
        {
            slider.value -= slowlyIncreasedValue/1.7f;
        }
    }
    public void increaseFrequencyWithBtn()
    {
        if (slider.value <= 308)
        {
            slider.value += .5f;
        }
    }
    public void decreaseFrequencyWithBtn()
    {
        if (slider.value >= 87.5)
        {
            slider.value -= .5f;
        }
    }
    public void checkSloution()
    {
        
        if (200.01f <= slider.value && slider.value <= 201.15)
        {
            Debug.Log("you won");
            isSolved= true;
            playMuisc();
            onWin();
        }
    }
    public void PlayMusicbtn()
    {
        PlayMusic = !PlayMusic;
        playMuisc();
    }
}
