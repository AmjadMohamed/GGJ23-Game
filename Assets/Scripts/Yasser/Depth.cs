using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    private SpriteRenderer renderer;
    private int sortingOrder = 1;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.sortingOrder = (int)Camera.main.WorldToScreenPoint(this.transform.position).y * sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.transform.position.y > collision.transform.position.y)
        {
            sortingOrder = -1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sortingOrder = 1;
    }
}