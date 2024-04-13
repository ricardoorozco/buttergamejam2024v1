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
        zoomInPoint.gameObject.SetActive(false);
        spawnTurretsListUI.SetActive(true);
        TurretsListUI.SetActive(true);
        zoomOutPoint.gameObject.SetActive(true);

        Camera.main.transform.position = zoomInPoint.position;
        Camera.main.transform.rotation = zoomInPoint.rotation;
    }

    public void zoomOutStation()
    {
        TurretsListUI.SetActive(false);
        spawnTurretsListUI.SetActive(false);
        zoomOutPoint.gameObject.SetActive(false);
        zoomInPoint.gameObject.SetActive(true);

        Camera.main.transform.position = zoomOutPoint.position;
        Camera.main.transform.rotation = zoomOutPoint.rotation;
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
