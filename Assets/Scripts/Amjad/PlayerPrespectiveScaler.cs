using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrespectiveScaler : MonoBehaviour
{
    [SerializeField] float ScaleModifier;
    private Vector3 StartPosScale;

    private void Start()
    {
        StartPosScale = this.transform.localScale;
    }

    private void Update()
    {
        float VerticalMov = Input.GetAxis("Vertical") * -1;
        print(VerticalMov);
        if (VerticalMov > 0 && transform.localScale.y < 3)
        {
            this.transform.localScale = new Vector3(transform.localScale.x + VerticalMov * ScaleModifier, transform.localScale.y + VerticalMov * ScaleModifier, transform.localScale.z + VerticalMov * ScaleModifier);
        }else if(VerticalMov < 0 &&transform.localScale.y > 1.2)
        {
            this.transform.localScale = new Vector3(transform.localScale.x + VerticalMov * ScaleModifier, transform.localScale.y + VerticalMov * ScaleModifier, transform.localScale.z + VerticalMov * ScaleModifier);
        }

    }
}
