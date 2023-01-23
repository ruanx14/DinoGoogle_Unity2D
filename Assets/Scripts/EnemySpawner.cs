using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] cactiThinPrefabs;
    public GameObject dinoFlyPrefab;


    public float initialDelay;
    //public float delayBetween; //Not used anymore
    public float distanceMinSpawn = 5.5f;
    public float distanceMaxSpawn = 9f;

    public float dinoFlyMinY = 0, dinoFlyMaxY = 1.5f;
    public Dino dino;
    private void Start()
    {

        //InvokeRepeating("GenerateEnemy", initialDelay, delayBetween);
        StartCoroutine(GenerateEnemy());
    }

    // Update is called once per frame
    private IEnumerator GenerateEnemy()
    {
        yield return new WaitForSeconds(initialDelay);
        GameObject lastEnemySpawned = null;
        var distanceEnemy = 0f;
        while (true) {
            var createEnemyController = lastEnemySpawned == null || Vector3.Distance(transform.position, lastEnemySpawned.transform.position) >= distanceEnemy;

            if (createEnemyController)
            {
                int controller = Random.Range(1, 7);
                if (dino.score >= 300 && controller <= 2)
                {
                    var positionRandomY = Random.Range(dinoFlyMinY, dinoFlyMaxY);
                    Vector3 position = new Vector3(
                        transform.position.x,
                        transform.position.y + positionRandomY,
                        transform.position.z
                        );
                    lastEnemySpawned = Instantiate(dinoFlyPrefab, position, Quaternion.identity);
                    
                }
                else
                {
                    int cactiQuantity = cactiThinPrefabs.Length;
                    int randomCacti = Random.Range(0, cactiQuantity);
                    var cactiThinPrefab = cactiThinPrefabs[randomCacti];
                    lastEnemySpawned = Instantiate(cactiThinPrefab, transform.position, Quaternion.identity);
                }
                distanceEnemy = Random.Range(distanceMinSpawn, distanceMaxSpawn);
            }
            yield return null;
            //yield return new WaitForSeconds(delayBetween);
        }
    }

}
