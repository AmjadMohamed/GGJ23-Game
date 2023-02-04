using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePhotoAlbumTutorial : MonoBehaviour
{
    // can get the number of interactables with the event system if we gonna go with that solution 
    public int NumberOfInteractsToActivateAlbum;
    [SerializeField] Button PhotoAlbum;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] GameObject Inventory;


    private int InteractsCnt;
    private bool IsTutorialShown = false;

    private void Update()
    {
        if (InteractsCnt == NumberOfInteractsToActivateAlbum && !IsTutorialShown)
        {
            TutorialPanel.SetActive(true);
            PhotoAlbum.interactable = true;
            IsTutorialShown = true;
            Inventory.SetActive(true);
        }

        // this is a placeholder to test the tutorial functionality
        if(Input.GetKeyDown(KeyCode.L))
        {
            InteractsCnt++;
        }
    }
}
