using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Animator anim;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    private bool movementDisabled = false;
    private SpriteRenderer playerSpriteRenderer;

    private Rigidbody2D playerRigidbody2D;


    private void Start()
    {
        anim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }
    }

    private void FixedUpdate()
    {
        if (!movementDisabled)
            Movement();
    }

    private void Movement()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        verticalMove = Input.GetAxis("Vertical") * speed;

        //transform.Translate(horizontalMove * Time.deltaTime * Vector2.right);
        //transform.Translate(verticalMove * Time.deltaTime * Vector2.up);

        playerRigidbody2D.velocity = new Vector3(
            horizontalMove,
            verticalMove
            );

        if (Input.GetAxis("Horizontal") >= 0)
            playerSpriteRenderer.flipX = true;
        else
            playerSpriteRenderer.flipX = false;
    }

    public void DisableMovement()
    {
        movementDisabled = false;
    }

    public void EnableMovement()
    {
        movementDisabled = true;
    }
}
