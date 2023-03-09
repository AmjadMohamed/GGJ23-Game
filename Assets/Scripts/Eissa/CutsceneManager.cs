using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] DialogueUI dialogueManager;
    [SerializeField] DialogueObject[] dialogues;
    [SerializeField] GameObject[] cams;
    [SerializeField] GameObject dialoguePanel;
    //[SerializeField] DialogueObject dialogue1 , dialogue2, dialogue3, dialogue4;
    private void Start()
    {
        //cams[0].SetActive(true);
        //dialogueManager.ShowDialogue(dialogue1);
        StartCoroutine(startingCutscene());
    }
    
    IEnumerator startingCutscene()
    {
        for (int i = 0; i < dialogues.Length; i++)
         {
             cams[i].gameObject.SetActive(true);
             dialogueManager.ShowDialogue(dialogues[i]);
             yield return new WaitForSeconds(5);
         }
        //dialogueManager.CloseDialogue();
        dialoguePanel.SetActive(false);
        cams[5].SetActive(true);
        yield return new WaitForSeconds(2.1f);
        
        if (GameManager.Instance == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            GameManager.Instance.StartGame();
        }

        //yield return new WaitForSeconds(4);
        //cams[1].SetActive(true);
        //dialogueManager.ShowDialogue(dialogue2);
        //yield return new WaitForSeconds(4);
        //cams[2].SetActive(true);
        //dialogueManager.ShowDialogue(dialogue3);
        //yield return new WaitForSeconds(4);
        //cams[3].SetActive(true);
        //dialogueManager.ShowDialogue(dialogue4);
        //yield return new WaitForSeconds(4);

    }
}
