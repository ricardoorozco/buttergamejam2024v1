using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] enemyShips;
    [SerializeField]
    private float timeDelayStart;
    public float timeDelaySpawn;
    [SerializeField]
    private float timeDelay;
    [SerializeField]
    private float timeToNextPoint;
    [SerializeField]
    private int shipScore;

    void Awake()
    {
        StageController stageController = GameObject.Find("StageController").GetComponent<StageController>();
        shipScore = GameController.instance.GetSelectedLvl() * stageController.getWave();
    }

    void Start()
    {
        timeDelay = timeDelayStart;
        this.Spawn();
    }

    private void Spawn()
    {
        if (!GameController.instance.isGameOver)
        {
            LeanTween.delayedCall(timeDelay, () =>
            {
                timeDelay = timeDelaySpawn;

                GameObject enemyGameObject = Instantiate(enemy, transform.position, Quaternion.identity);

                GameObject enemyShip = Instantiate(enemyShips[Random.Range(0, enemyShips.Length)], enemyGameObject.transform.position, Quaternion.identity);
                enemyGameObject.GetComponent<StationManager>().score = shipScore;
                enemyShip.transform.SetParent(enemyGameObject.transform);

                EnemyFollowPathController enemyFollowPathController = enemyGameObject.GetComponent<EnemyFollowPathController>();
                enemyFollowPathController.SetNextPoint(this.transform.GetComponent<PathInfo>().GetNextPoint());
                enemyFollowPathController.SetTimeDelay(timeToNextPoint);
                enemyFollowPathController.goToNextPoint();
                this.Spawn();
            });
        }
    }
}
