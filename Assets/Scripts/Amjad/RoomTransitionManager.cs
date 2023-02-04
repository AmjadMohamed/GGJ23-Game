using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitionManager : MonoBehaviour
{
    [SerializeField] List<Transform> RoomCams;
    [SerializeField] GameObject PhotoAlbum;
    [SerializeField] GameObject Player;


    private int GetActiveCam()
    {
        for (int i = 0; i < RoomCams.Count; i++)
        {
            if (RoomCams[i].gameObject.activeSelf)
            {
                return i;
            }
        }
        return -1;
    }


    public void MoveToRoom(int RoomNumber)
    {
        if (RoomNumber - 1 != GetActiveCam())
            StartCoroutine("MovePlayerWithCamera");

        for (int i = 0; i < RoomCams.Count; i++)
        {
            RoomCams[i].gameObject.SetActive(false);
        }
        PhotoAlbum.SetActive(false);
        RoomCams[RoomNumber - 1].gameObject.SetActive(true);
    }

    IEnumerator MovePlayerWithCamera()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<CircleCollider2D>().enabled = false;
        Player.GetComponent<BoxCollider2D>().enabled = false;
        Player.transform.SetParent(Camera.main.transform);
        yield return new WaitForSeconds(Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time);
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<CircleCollider2D>().enabled = true;
        Player.GetComponent<BoxCollider2D>().enabled = true;
        Player.transform.SetParent(null);
    }
}
