using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text textComponent;
    public AudioSource audioSource;
    public float typingSpeed = 0.05f;

    [SerializeField]
    private string[] message;
    [SerializeField]
    private int currentParagraph = 0;
    [SerializeField]
    private bool canTyping = true;
    [SerializeField]
    private bool typing = true;
    [SerializeField]
    private GameObject buttonNext;

    IEnumerator TypeText(string text)
    {
        typing = true;
        canTyping = false;
        textComponent.text = "";

        foreach (char letter in text.ToCharArray())
        {
            textComponent.text += letter;
            audioSource.Play();
            yield return new WaitForSeconds(typingSpeed);
        }

        typing = false;
        canTyping = true;
    }

    private void Start()
    {
        buttonNext.SetActive(true);
        StartCoroutine(TypeText(message[currentParagraph]));
        currentParagraph++;
    }

    public void nextParagrapf()
    {
        if(typing)
        {
            StopAllCoroutines();
            textComponent.text = message[currentParagraph - 1];
            typing = false;
            canTyping = true;
            return;
        }

        if (currentParagraph >= message.Length)
        {
            buttonNext.SetActive(false);
            canTyping = false;
        }
        if (canTyping)
        {
            StartCoroutine(TypeText(message[currentParagraph]));
            currentParagraph++;
        }
    }
}
