using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        verticalMove = Input.GetAxis("Vertical") * speed;

        transform.Translate(horizontalMove * Time.deltaTime * Vector2.right);
        transform.Translate(verticalMove * Time.deltaTime * Vector2.up);
    }

    private void FixedUpdate()
    {
        
    }
}
