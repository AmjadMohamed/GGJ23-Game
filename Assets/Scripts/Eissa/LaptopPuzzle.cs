using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.Burst.CompilerServices;

public class LaptopPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text feedback;
    [SerializeField] GameObject hintText;
    string enteredPassword;
    string correctPassword = "forgetmenot";
    [SerializeField] PlayerMovement playerRef;
    string concatString = "";
    string[] splitedStr;


    int hintCount = 0;

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
        enteredPassword.Trim();
        if (enteredPassword.Contains('-'))
        {
            splitedStr = enteredPassword.Split('-');

            for (int i = 0; i < splitedStr.Length; i++)
            {
                concatString += splitedStr[i];
            }
        }
        if (concatString.Contains(' '))
        {
            splitedStr = concatString.Split(' ');
            concatString = "";
            for (int i = 0; i < splitedStr.Length; i++)
            {
                concatString += splitedStr[i];
            }
        }
        else if (enteredPassword.Contains(' '))
        {
           splitedStr = enteredPassword.Split(' ');
           
            for (int i = 0; i < splitedStr.Length; i++)
            {
                concatString += splitedStr[i];
            }
        }
        Debug.Log(concatString);
        if (concatString == correctPassword || enteredPassword == correctPassword)
        {
            Debug.Log("you won");
            feedback.text = "Correct Password";
            onWin();
        }
        else
        {
            feedback.text = "Wrong Password, please try agian";
            hintCount++;
            if(hintCount > 0)
            {
                hintText.SetActive(true);
            }
        }
    }

}
