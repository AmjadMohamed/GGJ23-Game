using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    bool activeState = true;
    [SerializeField] GameObject panel;
   public void switchThePanal()
    {

        panel.SetActive(activeState);
        activeState = !activeState;
    }
}
