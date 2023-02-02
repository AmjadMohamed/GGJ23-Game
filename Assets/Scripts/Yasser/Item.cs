using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour, Interactable
{
    [SerializeField] Sprite interactableSprite;
    [SerializeField] float distanceRange;
    [SerializeField] private TextMeshProUGUI puzzlePanel;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerBehavior player;


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
            Inspect();
        }

    }

    private void CheckDistance()
    {
        float distance2Player = Vector2.Distance(this.transform.position, player.transform.position);

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
        player.EnableInspectText();
        StartCoroutine(DisableInspectText());
    }

    public void Interact()
    {
        puzzlePanel.gameObject.transform.parent.gameObject.SetActive(true);
        playerMovement.DisableMovement();
    }

    IEnumerator DisableInspectText()
    {
        yield return new WaitForSeconds(3);
        player.DisableInspectText();
    }
}
