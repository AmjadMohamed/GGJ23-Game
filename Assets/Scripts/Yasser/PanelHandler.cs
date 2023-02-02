using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    public void ExitPanel()
    {
        player.EnableMovement();
        this.gameObject.SetActive(false);
    }
}
