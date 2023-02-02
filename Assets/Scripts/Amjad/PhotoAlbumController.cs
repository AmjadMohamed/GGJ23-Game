using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoAlbumController : MonoBehaviour
{
    [SerializeField] List<GameObject> RoomPics;
    int cnt = 0;

    private void Start()
    {
        for (int i = 0; i < RoomPics.Count; i++)
        {
            RoomPics[i].SetActive(false);
        }
        RoomPics[cnt].SetActive(true);
    }

    public void NextButton()
    {
        RoomPics[cnt].SetActive(false);
        cnt++;

        if (cnt >= RoomPics.Count)
            cnt = 0;

        RoomPics[cnt].SetActive(true);
    }

    public void BackButton()
    {
        RoomPics[cnt].SetActive(false);
        cnt--;

        if (cnt < 0)
            cnt = RoomPics.Count - 1;

        RoomPics[cnt].SetActive(true);
    }


}
