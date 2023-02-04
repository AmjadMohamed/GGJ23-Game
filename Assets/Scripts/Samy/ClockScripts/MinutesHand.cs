using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MinutesHand : MonoBehaviour
{
    Vector3 mouse_pos;
    private Transform target;
    private Vector3 object_pos;
    private float angle;
    public bool isLocal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void OnMouseOver()
    {

        if(Input.GetMouseButtonDown(0)) {

                transform.Rotate(0,0,-30);
            }
        if (Input.GetMouseButtonDown(1))
        {

            transform.Rotate(0, 0, 30);
        }

    }
    
    private float Angle()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -20;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        return angle;
    }
}
