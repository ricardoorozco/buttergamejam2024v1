using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSystem : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public void Start()
    {
        //StartCoroutine(Up());
        UpLeanTween();
    }

    IEnumerator Up()
    {
        while (true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            yield return new WaitForSeconds(0.01f);
        }
    }

    // IEnumerator Up() but in a leantween function
    void UpLeanTween()
    {
        LeanTween.moveLocalY(gameObject, 50, 10).setEase(LeanTweenType.easeOutBounce);
    }
}
