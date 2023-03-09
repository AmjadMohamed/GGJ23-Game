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
    [SerializeField] Image currentimg;
    [SerializeField] Sprite Pushedbtn;
    [SerializeField] Sprite notPushedbtn;
    [SerializeField] Sprite solvedSprite;
    [SerializeField] Button RadioOnOffButton;
    //[SerializeField] AudioClip staticSound,theSong;
    float slowlyIncreasedValue = 0.01f;
    bool PlayMusic = false;
    bool isSolved = false;
    void playMusicFunc()
    {
        if (PlayMusic)
        {
            if (isSolved)
            {
                AudioManager_.instance.stopSFX("radio_static_5s");
                AudioManager_.instance.playMusic("Ansak - Umm Kulthum");
            }
            else
            {
                AudioManager_.instance.playSFX("radio_static_5s");
                AudioManager_.instance.loopSFX("radio_static_5s");
            }
        }
    }
    private void onWin()
    {
        //call here the dialogue function and the inventory function
        isSolved = true;
        print("radio solved");
        slider.interactable = false;
        RadioOnOffButton.interactable = false;
        currentimg.sprite = solvedSprite;
        //AudioManager_.instance.sfxSource.gameObject.SetActive(false);
        GameManager.Instance.FinishRadioPuzzle();
    }
    private void OnEnable()
    {
        GameManager.Instance.SetPlayerEnabled(false);
        playerRef.DisableMovement();
        //AudioManager_.instance.stopSFX("radio_static_5s");
    }
    private void OnDisable()
    {
        GameManager.Instance.SetPlayerEnabled(true);
        playerRef.EnableMovement();
    }
    //public void onCloseingThePuzzle()
    //{
    //    playerRef.EnableMovement();
    //}

    private void Update()
    {
        Debug.Log("can play music: " + PlayMusic);
        Debug.Log("is solved: " + isSolved);
        if (!isSolved)
        {
            //AudioManager_.instance.playSFX("radio_static_5s");
            //AudioManager_.instance.loopSFX("radio_static_5s");
            if (Input.GetKey(KeyCode.RightArrow))
            {
                increaseFrequency();
                slowlyIncreasedValue += (slowlyIncreasedValue * Time.deltaTime);
            }

            //else if (Input.GetKeyDown(KeyCode.RightArrow))
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                slowlyIncreasedValue = 0.01f;
                //checkSloution();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                slowlyIncreasedValue += (slowlyIncreasedValue * Time.deltaTime);
                decreaseFrequency();

            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {

                slowlyIncreasedValue = 0.01f;
                //checkSloution();
            }
        }

        if (PlayMusic)
        {
            if (slider.value > 195 && slider.value < 230)
            {
                playMusicFunc();
                onWin();
            }
        }
    }
    public void increaseFrequency()
    {
        if (slider.value <= 308)
        {
            slider.value += slowlyIncreasedValue / 1.7f;
        }
    }
    public void decreaseFrequency()
    {
        if (slider.value >= 87.5)
        {
            slider.value -= slowlyIncreasedValue / 1.7f;
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
    //public void checkSloution()
    //{

    //    if (195 <= slider.value && slider.value <= 230)
    //    {
    //        Debug.Log("you won");
    //        isSolved = true;
    //        playMusicFunc();
    //        onWin();
    //        slider.interactable = false;
    //        currentimg.sprite = solvedSprite;
    //    }
    //}
    public void PlayMusicbtn()
    {
        PlayMusic = !PlayMusic;
        if (PlayMusic)
        {
            currentimg.sprite = Pushedbtn;
            slider.interactable = true;
            playMusicFunc();
        }
        else
        {
            currentimg.sprite = notPushedbtn;
            slider.interactable = false;
            AudioManager_.instance.musicSource.Stop();
            AudioManager_.instance.sfxSource.Stop();

        }
    }
}
