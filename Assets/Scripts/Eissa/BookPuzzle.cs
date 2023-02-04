using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class BookPuzzle : MonoBehaviour
{
    GameObject selectedBook1 = null;
    GameObject selectedBook2 = null;
    [SerializeField] List<GameObject> btns= new List<GameObject>();
    [SerializeField] int[] rightOrder = {1,2,3,4,5};
    bool solved = false;

    void onWin()
    {
        //call here the dialogue function and the inventory function

    }
    public void SelectedBook(GameObject btn)
    {
        if (!solved)
        {

            if(selectedBook1 == null)
            {
                selectedBook1 = btn;
                Debug.Log("btn1 Selected");
            }
            else if (selectedBook1 == btn)
            {
                return;
            }
            else
            {
                selectedBook2 = btn;
                Debug.Log("btn2 Selected");
                switchBooks();
            }

        }

    }
    void switchBooks()
    {
        int book1id =  selectedBook1.GetComponent<book>().id;
        int book2id =  selectedBook2.GetComponent<book>().id;

        int tempid = 0;
        Sprite book1img = selectedBook1.GetComponent<Image>().sprite;
        Sprite book2img = selectedBook2.GetComponent<Image>().sprite;
        Sprite tempSprite = null;
        tempid = book1id;
        book1id = book2id;
        book2id = tempid;

        tempSprite = book1img;
        book1img = book2img;
        book2img = tempSprite;

        selectedBook1.GetComponent<book>().id = book1id;
        selectedBook2.GetComponent<book>().id = book2id;
        selectedBook1.GetComponent<Image>().sprite = book1img;
        selectedBook2.GetComponent<Image>().sprite = book2img;
        selectedBook1= null;
        selectedBook2= null;

        chackOrder();
    }
    void chackOrder()
    {
        for (int i = 0; i < rightOrder.Length; i++)
        {
            int id = btns[i].GetComponent<book>().id;
            if (rightOrder[i] != id )
            {
                return;
            }
        }
        Debug.Log("you won");
        solved = true;
        onWin();
    }
    public void onCloseingThePuzzle()
    {
        selectedBook1 = null;
        selectedBook2 = null;
    }
    
}
