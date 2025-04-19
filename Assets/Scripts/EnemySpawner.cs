using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float spawnrate;
    [SerializeField] private float spawnratevariance;
    [SerializeField] private float diffucultyrate;
    [SerializeField] private float spawnfactor;
    [SerializeField] private GameObject regularenemy;
    [SerializeField] private GameObject bouncer;
    [SerializeField] private GameObject chomper;
    [SerializeField] private GameObject l_r;
    [SerializeField] List<GameObject> spawnpoints = new List<GameObject>();
    private float spawntimestamp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float randomVariance = Random.Range(-spawnratevariance, spawnratevariance);
        float minValue = Mathf.Min(regularenemy.GetComponent<EnemyValues>().cost, bouncer.GetComponent<EnemyValues>().cost, chomper.GetComponent<EnemyValues>().cost, l_r.GetComponent<EnemyValues>().cost);
        if (diffucultyrate >= minValue)
        {
            if (Time.time > spawntimestamp)
            {
                print(EnemyPicker().name);
                spawntimestamp = Time.time + spawnrate + randomVariance;
            }
        }


    }
    private Transform RandomSpawnPoint()
    {
        int randompoint = Random.Range(0, 5);
        return spawnpoints[randompoint].transform;
    }
    private GameObject EnemyPicker()
    {
        List<GameObject> affordableEnemies = new List<GameObject>();

        if (diffucultyrate >= regularenemy.GetComponent<EnemyValues>().cost)
            affordableEnemies.Add(regularenemy);
        if (diffucultyrate >= bouncer.GetComponent<EnemyValues>().cost)
            affordableEnemies.Add(bouncer);
        if (diffucultyrate >= chomper.GetComponent<EnemyValues>().cost)
            affordableEnemies.Add(chomper);
        if (diffucultyrate >= l_r.GetComponent<EnemyValues>().cost)
            affordableEnemies.Add(l_r);

        if (affordableEnemies.Count > 0)
        {
            GameObject selected = affordableEnemies[Random.Range(0, affordableEnemies.Count)];
            diffucultyrate -= selected.GetComponent<EnemyValues>().cost;
            return selected;
        }

        return null;
    }


}
