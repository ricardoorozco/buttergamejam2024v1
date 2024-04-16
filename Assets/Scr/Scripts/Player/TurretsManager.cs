using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsManager : MonoBehaviour
{
    [SerializeField]
    private Transform zoomInPoint;
    [SerializeField]
    private Transform zoomOutPoint;
    [SerializeField]
    private Transform zoomInButton;
    [SerializeField]
    private Transform zoomOutButton;
    [SerializeField]
    private GameObject TurretsListUI;
    [SerializeField]
    private GameObject spawnTurretsListUI;

    [SerializeField]
    private GameObject[] turrets;

    [SerializeField]
    private int currentSelectedTurret = -1;

    private void Awake()
    {
        zoomOutStation();
    }

    public void zoomInStation()
    {
        TurretsListUI.SetActive(true);
        spawnTurretsListUI.SetActive(true);
        zoomInButton.gameObject.SetActive(false);
        zoomOutButton.gameObject.SetActive(true);

        //Camera.main.transform.position = zoomInPoint.position;
        //Camera.main.transform.rotation = zoomInPoint.rotation;
        LeanTween.move(Camera.main.gameObject, zoomInPoint.position, 1f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.rotate(Camera.main.gameObject, zoomInPoint.rotation.eulerAngles, 1f).setEase(LeanTweenType.easeOutQuad);
    }

    public void zoomOutStation()
    {
        TurretsListUI.SetActive(false);
        spawnTurretsListUI.SetActive(false);
        zoomOutButton.gameObject.SetActive(false);
        zoomInButton.gameObject.SetActive(true);

        //Camera.main.transform.position = zoomOutPoint.position;
        //Camera.main.transform.rotation = zoomOutPoint.rotation;
        LeanTween.move(Camera.main.gameObject, zoomOutPoint.position, 1f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.rotate(Camera.main.gameObject, zoomOutPoint.rotation.eulerAngles, 1f).setEase(LeanTweenType.easeOutQuad);
    }

    public GameObject GetTurret()
    {
        if (currentSelectedTurret >= 0 && currentSelectedTurret < turrets.Length) {
            return turrets[currentSelectedTurret];
        } 
        else
        {
            return null;
        }
    }

    public void SetCurrentSelectedTurret(int index)
    {
        currentSelectedTurret = index;
    }
}
