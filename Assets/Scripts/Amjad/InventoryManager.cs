using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;

    public static InventoryManager Instance { get => instance; set => instance = value; }
    public GameObject PhotoAlbum;
    public GameObject Inventory_OldClockHand;
    public GameObject Inventory_ModernClockHand;
    public GameObject Inventory_SemiModernClockHand;
    public GameObject Inventory_Key;
    public GameObject Inventory_Seed;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void OpenClosePhotoAlbum()
    {
        if(PhotoAlbum.activeSelf)
        {
            PhotoAlbum.SetActive(false);
        }
        else
        {
            PhotoAlbum.SetActive(true);
        }
    }



}
