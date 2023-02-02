using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    private bool movementDisabled = false;

    // Update is called once per frame
    void Update()
    {
        if (!movementDisabled)
            Movement();
    }

    private void Movement()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        verticalMove = Input.GetAxis("Vertical") * speed;

        transform.Translate(horizontalMove * Time.deltaTime * Vector2.right);
        transform.Translate(verticalMove * Time.deltaTime * Vector2.up);
    }

    public void DisableMovement()
    {
        movementDisabled = true;
    }

    public void EnableMovement()
    {
        movementDisabled = false;
    }
}
