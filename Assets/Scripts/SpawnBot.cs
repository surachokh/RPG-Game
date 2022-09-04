using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{

    [SerializeField] GameObject BotPrefabs;

    void Start()
    {
    }

    public void onClick()
    {
        InvokeRepeating("Spawn", 3, 3);
    }

    void Spawn()
    {
        float xValue = Random.Range(-24f, 24f);
        float zValue = Random.Range(-24f, 24f);

        Vector3 spawnPosition = new Vector3(xValue, 0.5f, zValue);

        Instantiate(BotPrefabs, spawnPosition, Quaternion.identity).SetActive(true);
    }

}
