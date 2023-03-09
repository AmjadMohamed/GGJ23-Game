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

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();

        if (GameManager.Instance != null)
        {
            GameManager.Instance.PauseGameEvent.AddListener(OnPauseGame);
            GameManager.Instance.EnablePlayerEvent.AddListener(OnPauseGame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movementDisabled)
        {
            return;
        }
           
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

        playerRigidbody2D.velocity = new Vector3(
            horizontalMove,
            verticalMove
            );

        if (Input.GetKey(KeyCode.D) && Input.GetAxis("Horizontal") >= 0)
        {
            playerSpriteRenderer.flipX = true;
        }
        
        if (Input.GetKey(KeyCode.A) && Input.GetAxis("Horizontal") <= 0)
        {
            playerSpriteRenderer.flipX = false;
        }
    }

    public void DisableMovement()
    {
        movementDisabled = true;
    }

    public void EnableMovement()
    {
        movementDisabled = false;
    }

    public void OnPauseGame(bool isGamePause)
    {
        if (!isGamePause)
        {
            DisableMovement();
            //anim.StopPlayback();
        }

        if (isGamePause)
        {
            EnableMovement();
            //anim.StartPlayback();
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PauseGameEvent.RemoveListener(OnPauseGame);
            GameManager.Instance.EnablePlayerEvent.RemoveListener(OnPauseGame);
        }
    }
}
