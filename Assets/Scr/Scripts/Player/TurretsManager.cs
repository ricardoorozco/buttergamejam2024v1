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
    private GameObject TurretsListUI;

    [SerializeField]
    private GameObject[] turrets;

    private void Awake()
    {
        zoomOutStation();
    }

    public void zoomInStation()
    {
        zoomInPoint.gameObject.SetActive(false);
        TurretsListUI.SetActive(true);
        zoomOutPoint.gameObject.SetActive(true);

        Camera.main.transform.position = zoomInPoint.position;
        Camera.main.transform.rotation = zoomInPoint.rotation;
    }

    public void zoomOutStation()
    {
        TurretsListUI.SetActive(false);
        zoomOutPoint.gameObject.SetActive(false);
        zoomInPoint.gameObject.SetActive(true);

        Camera.main.transform.position = zoomOutPoint.position;
        Camera.main.transform.rotation = zoomOutPoint.rotation;
    }
}
