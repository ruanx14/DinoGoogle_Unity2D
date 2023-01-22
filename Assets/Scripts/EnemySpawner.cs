using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] cactiThinPrefabs;
    public GameObject dinoFlyPrefab;


    public float initialDelay;
    public float delayBetween;

    public float dinoMinX, dinoMaxX;
    public Dino dino;
    private void Start()
    {
        InvokeRepeating("GenerateEnemy", initialDelay, delayBetween);
    }

    // Update is called once per frame
    private void GenerateEnemy()
    {
        int controller = Random.Range(1, 7);
        if(dino.score >= 300 && controller <=2)
        {
            var positionRandomY = Random.Range(dinoMinX, dinoMaxX);
            Vector3 position = new Vector3(
                transform.position.x,
                transform.position.y + positionRandomY,
                transform.position.z
                );
            Instantiate(dinoFlyPrefab, position, Quaternion.identity);
        }
        else
        {
            int cactiQuantity = cactiThinPrefabs.Length;
            int randomCacti = Random.Range(0, cactiQuantity);
            var cactiThinPrefab = cactiThinPrefabs[randomCacti];
            Instantiate(cactiThinPrefab, transform.position, Quaternion.identity);
        }
        
    }

}
