using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private GameObject _secondsHand;
    [SerializeField]
    private GameObject _MinutesHand;
    [SerializeField]
    private GameObject _hoursHand;
    bool isWin = false;
    float minutesDegree;
    float hoursDegree;

    // Start is called before the first frame update
    void Start()
    {
        //_MinutesHand.transform.localRotation *= Quaternion.Euler(new Vector3(minutesDegree, 0, 0));

        //_hoursHand.transform.localRotation *= Quaternion.Euler(new Vector3(-hoursDegree, 0, 0));

    }

    // Update is called once per frame
    void Update()
    {
        // DateTime currentTime = DateTime.Now;

        if (Input.GetKeyDown(KeyCode.D) && !isWin)
        {
            minutesDegree = (2f / 12f) * 360f;
            _MinutesHand.transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, minutesDegree));
        }

        if (Input.GetKeyDown(KeyCode.A) && !isWin)
        {
            minutesDegree = (2f / 12f) * 360f;
            _MinutesHand.transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, -minutesDegree));
        }

        //float secondsDegree = (currentTime.Second / 60f) * 360f;
        //_secondsHand.transform.localRotation = Quaternion.Euler(new Vector3(secondsDegree, 0, 0));

        if (Input.GetKeyDown(KeyCode.RightArrow) && !isWin)
        {
            hoursDegree = (3f / 12f) * 360f;
            _hoursHand.transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, hoursDegree));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isWin)
        {
            hoursDegree = (3f / 12f) * 360f;
            _hoursHand.transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, -hoursDegree));
        }
        if(_MinutesHand.transform.localRotation == _hoursHand.transform.localRotation)
        {
            //print("YOU WON PEICE OF SHIT");
            isWin= true;
        }

    }
}