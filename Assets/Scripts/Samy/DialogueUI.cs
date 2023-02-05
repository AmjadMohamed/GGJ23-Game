using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] TMP_Text text_panel;
    [SerializeField] DialogueObject testDialogue;
    [SerializeField] GameObject dialougebox;

    private TypeWriterEffect typeWriterEffect;

    private void Awake()
    {
        typeWriterEffect= GetComponent<TypeWriterEffect>();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        Debug.Log("in Show Dialogue");
        dialougebox.SetActive(true);
        StartCoroutine(stepThroughDialogue(dialogueObject));
    }

    private IEnumerator stepThroughDialogue(DialogueObject dialogueObject)
    {
        Debug.Log("Before foreach");

        foreach(string dialogue in dialogueObject.Dialogue)
        {
            Debug.Log("In foreach");
            yield return typeWriterEffect.Run(dialogue, text_panel);
            yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
        }
        CloseDialogue();
    }

    private void CloseDialogue()
    {
        player.EnableMovement();
        dialougebox.SetActive(false);
        text_panel.text= string.Empty;
    }
}
