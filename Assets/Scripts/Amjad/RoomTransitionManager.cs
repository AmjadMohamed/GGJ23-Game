using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitionManager : MonoBehaviour
{
    [SerializeField] List<Transform> RoomCams;
    [SerializeField] GameObject PhotoAlbum;

    public void MoveToRoom(int RoomNumber)
    {
        for (int i = 0; i < RoomCams.Count; i++)
        {
            RoomCams[i].gameObject.SetActive(false);
        }
        PhotoAlbum.SetActive(false);
        RoomCams[RoomNumber - 1].gameObject.SetActive(true);
    }
}
