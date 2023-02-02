using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inspectText;

    public void EnableInspectText()
    {
        inspectText.gameObject.SetActive(true);
    }

    public void DisableInspectText()
    {
        inspectText.gameObject.SetActive(false);
    }
}
