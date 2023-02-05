using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour, Interactable
{
    [SerializeField] private Sprite interactableSprite;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float distanceRange;

    [SerializeField] private GameObject puzzlePanel;

    [SerializeField] private DialogueObject dialogue;
    [SerializeField] private DialogueUI dialogueManager;


    private SpriteRenderer spriteRenderer;
    private Sprite regularSprite;
    private bool isPuzzle = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        regularSprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        CheckDistance();

        if (Input.GetKeyDown(KeyCode.E) && isPuzzle)
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.F) && isPuzzle)
        {
            Debug.Log("f pressed");
            Inspect();
        }
    }

    private void CheckDistance()
    {
        float distance2Player = Vector2.Distance(this.transform.position, playerMovement.transform.position);

        if (distance2Player <= distanceRange)
        {
            isPuzzle = true;
            SwapSprite(interactableSprite);
        }
        else
        {
            isPuzzle = false;
            spriteRenderer.sprite = regularSprite;
        }
    }

    public void SwapSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    public void Inspect()
    {
        Debug.Log("In inspect");
        dialogueManager.ShowDialogue(dialogue);
        playerMovement.DisableMovement();
    }

    public void Interact()
    {
        puzzlePanel.SetActive(true);
        playerMovement.DisableMovement();
    }
}
