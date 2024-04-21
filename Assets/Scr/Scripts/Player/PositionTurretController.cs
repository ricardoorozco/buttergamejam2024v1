using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PositionTurretController : MonoBehaviour
{
    [SerializeField]
    TurretsManager turretsManager;

    [SerializeField]
    private bool canPutTurret = true;

    [SerializeField]
    private StageController stageController;

    [SerializeField]
    private Animator alertAnimation;
    [SerializeField]
    private TMP_Text alertText;

    void Awake()
    {
        stageController = GameObject.Find("StageController").GetComponent<StageController>();
    }

    public void PutTurret() {
        if (canPutTurret) {
            GameObject turret = turretsManager.GetTurret();
            
            if (turret)
            {
                Turret turretScript = turret.GetComponent<Turret>();
                if (turretScript.cost <= stageController.getSupply())
                {
                    stageController.addSupply(-turretScript.cost);
                    GameObject turretIntance = Instantiate(turret, transform.position, transform.rotation);
                    turretIntance.transform.parent = transform;
                    turretIntance.transform.localScale = new Vector3(1, 1, 1);
                    canPutTurret = false;
                }
                else
                {
                    alertText.text = "Piezas Insuficientes";
                    alertAnimation.gameObject.SetActive(false);
                    alertAnimation.gameObject.SetActive(true);
                }
            }
        }
    }
}
