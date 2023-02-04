using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public GameEvent gameEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameEvent.Raise();
    }
}
