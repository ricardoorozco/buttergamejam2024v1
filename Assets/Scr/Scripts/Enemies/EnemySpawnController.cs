using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] enemyShips;
    [SerializeField]
    private float timeDelay;
    [SerializeField]
    private float timeToNextPoint;

    void Start()
    {
        this.Spawn();
    }

    private void Spawn()
    {
        float randomTime = Random.Range(timeDelay-1, timeDelay+1);
        LeanTween.delayedCall(randomTime, () => {
            
            //create enemy
            GameObject enemyGameObject = Instantiate(enemy, transform.position, Quaternion.identity);
            
            //set ship model as child
            GameObject enemyShip = Instantiate(enemyShips[Random.Range(0, enemyShips.Length)], enemyGameObject.transform.position, Quaternion.identity);
            enemyShip.transform.SetParent(enemyGameObject.transform);

            //set and go to next point
            EnemyFollowPathController enemyFollowPathController = enemyGameObject.GetComponent<EnemyFollowPathController>();
            enemyFollowPathController.SetNextPoint(this.transform.GetComponent<PathInfo>().GetNextPoint());
            enemyFollowPathController.SetTimeDelay(timeToNextPoint);
            enemyFollowPathController.goToNextPoint();
            this.Spawn();
        });
    }
}
