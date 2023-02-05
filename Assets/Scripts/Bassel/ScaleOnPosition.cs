using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add this component to your player and the parallax effect will appear :D
public class ScaleOnPosition : MonoBehaviour
{
    [Header("Min Max Positions")]
    // Minimum vector corrosponding to the minimum position.
    [SerializeField] Vector3 minPosition = new Vector3(0, -1.8f, 0);

    // Maximum vector corrosponding to the maximum postition.
    [SerializeField] Vector3 maxPosition = new Vector3(0, -0.5f, 0);

    [Header("Min Max Scales")]
    [SerializeField] Vector3 maxScale = Vector3.one;

    [SerializeField] Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);


    private void Update()
    {
        // Where is the position in y between the min and max
        // and yes the 2 vectors (min/max) could be replaced by 2 floats, yet more understandable like that
        float positionLerpValue = Mathf.InverseLerp(minPosition.y, maxPosition.y, transform.position.y);

        // if below min or over max, get the lerp value between 0-1
        // to prevent that scale gets out our desired min max
        positionLerpValue = Mathf.Clamp01(positionLerpValue);

        // sets the actual scale of the player to the lerped value
        transform.localScale = Vector3.Lerp(maxScale, minScale, positionLerpValue);
    }
}
