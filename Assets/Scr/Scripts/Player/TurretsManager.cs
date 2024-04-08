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
    private GameObject[] turrets;

    private void Awake()
    {
        zoomOutStation();
    }

    public void zoomInStation() 
    {
        Camera.main.transform.position = zoomInPoint.position;
        Camera.main.transform.rotation = zoomInPoint.rotation;

        zoomInPoint.gameObject.SetActive(false);
        zoomOutPoint.gameObject.SetActive(true);
    }

    public void zoomOutStation()
    {
        Camera.main.transform.position = zoomOutPoint.position;
        Camera.main.transform.rotation = zoomOutPoint.rotation;

        zoomInPoint.gameObject.SetActive(true);
        zoomOutPoint.gameObject.SetActive(false);
    }
}
