using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TMP_Text text_panel;
    [SerializeField] DialogueObject[] testDialogue;
    [SerializeField] GameObject dialougebox;
    private TypeWriterEffect typeWriterEffect;
    private void Start()
    {

        typeWriterEffect= GetComponent<TypeWriterEffect>();
        CloseDialogue();
        ShowDialogue(testDialogue[0]);
    }
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialougebox.SetActive(true);
        StartCoroutine(stepThroughDialogue(dialogueObject));
    }
    private IEnumerator stepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach(string dialogue in dialogueObject.Dialogue)
        {
            yield return typeWriterEffect.Run(dialogue,text_panel);
            yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
        }
        CloseDialogue();
    }
    private void CloseDialogue()
    {
        dialougebox.SetActive(false);
        text_panel.text= string.Empty;
    }
}
