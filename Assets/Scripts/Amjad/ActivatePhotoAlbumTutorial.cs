using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePhotoAlbumTutorial : MonoBehaviour
{
    // can get the number of interactables with the event system if we gonna go with that solution 
    private static ActivatePhotoAlbumTutorial instance;

    //[HideInInspector] public int InteractsCnt;
    //[SerializeField] int NumberOfInteractsToActivateAlbum;
    [SerializeField] Button PhotoAlbum;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] GameObject Inventory;


    private bool IsTutorialShown = false;

    public static ActivatePhotoAlbumTutorial Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void ActivateInventoryTutorial()
    {
        TutorialPanel.SetActive(true);
        PhotoAlbum.interactable = true;
        IsTutorialShown = true;
        Inventory.SetActive(true);
    }
}
