using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextTyper : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private float typeDelay;

    private Text textGUI;

    private void OnEnable()
    {
        textGUI = GetComponent<Text>();
        text = text.Replace("\\n", "\n");
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textGUI.text = "";
        foreach (char letter in text.ToCharArray())
        {            
            textGUI.text += letter;
            yield return new WaitForSeconds(typeDelay);
        }
    }
}
