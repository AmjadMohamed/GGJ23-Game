using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyHands : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(logEverySecond());
    }

    IEnumerator logEverySecond()
    {
        while (true)
        {
            int n = Random.Range(0, 2);
            if (n == 0)transform.Rotate(0, 0, -6);
            else if (n == 1) transform.Rotate(0, 0, 6);
            yield return new WaitForSeconds(1);
        }
    }
}
