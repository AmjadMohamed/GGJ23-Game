using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] public float typeWriterSpeed = 50f;
    public Coroutine Run(string textToType,TMP_Text textLabel )
    {

        return StartCoroutine(routine: TypeText(textToType,  textLabel));
    }
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;
        //yield return new WaitForSeconds(2);
        float t  = 0f;
        int charIndex = 0;
        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0,charIndex);

            yield return null;

        }
        textLabel.text = textToType;
    }
}
