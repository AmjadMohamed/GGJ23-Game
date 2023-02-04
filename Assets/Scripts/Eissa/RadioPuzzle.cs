using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioPuzzle : MonoBehaviour
{
    [SerializeField] Button up;
    [SerializeField] Button down;
    [SerializeField] PlayerMovement playerRef;
    [SerializeField] Slider slider;
    float slowlyIncreasedValue = 0.01f;
    bool isSolved = false;
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
             slider.value += slowlyIncreasedValue/2;
        }
    }
    public void decreaseFrequency()
    {
        if (slider.value >= 87.5)
        {
            slider.value -= slowlyIncreasedValue/2;
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
        }
    }
}
