using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    void SwapSprite(Sprite newSprite);
    void Inspect();
    void Interact();
}
