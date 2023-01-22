using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactiSpawner : MonoBehaviour
{

    public GameObject[] cactiThinPrefabs;

    public float initialDelay;
    public float delayBetween;
    private void Start()
    {
        InvokeRepeating("CreateCacti", initialDelay, delayBetween);
    }

    // Update is called once per frame
    private void CreateCacti()
    {
        int cactiQuantity = cactiThinPrefabs.Length;
        int randomCacti = Random.Range(0, cactiQuantity);
        var cactiThinPrefab = cactiThinPrefabs[randomCacti];
        Instantiate(cactiThinPrefab, transform.position,Quaternion.identity);
    }

}
