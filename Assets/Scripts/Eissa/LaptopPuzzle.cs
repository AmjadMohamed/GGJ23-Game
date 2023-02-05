using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LaptopPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text text;
    string enteredPassword;
    string correctPassword = "hello";
    [SerializeField] PlayerMovement playerRef;

    private void onWin()
    {
        // call whatever functions needed to end the game;
    }
    private void OnEnable()
    {
        playerRef.DisableMovement();
    }
    private void OnDisable()
    {
        playerRef.EnableMovement();   
    }

    public void checkPassword()
    {
        enteredPassword = inputField.text ;
        enteredPassword.ToLower();
        correctPassword.Trim();
        if(enteredPassword == correctPassword)
        {
            Debug.Log("you won");
            text.text = "Correct Password";
            onWin();
        }
        else
        {
            text.text = "Wrong Password, please try agian";
        }
    }

}
