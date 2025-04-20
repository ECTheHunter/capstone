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
                GameObject enemy = EnemyPicker();
                GameObject spawnpoint = RandomSpawnPoint();
                if (enemy.GetComponent<Left_Right>() != null)
                {
                    if (spawnpoint.GetComponent<SpawnPointValues>().isvertical)
                    {
                        enemy.GetComponent<Left_Right>().l_r = false;
                    }
                    else
                    {
                        enemy.GetComponent<Left_Right>().l_r = true;
                        if (spawnpoint.GetComponent<SpawnPointValues>().directionleft)
                        {
                            enemy.GetComponent<Left_Right>().directionleft = true;
                        }
                        else
                        {
                            enemy.GetComponent<Left_Right>().directionleft = false;
                        }
                    }

                }
                if (enemy.GetComponent<Bouncer>() != null)
                {
                    if (spawnpoint.GetComponent<SpawnPointValues>().isvertical)
                    {
                        enemy.GetComponent<Bouncer>().isvertical = true;
                    }
                    else
                    {
                        enemy.GetComponent<Bouncer>().isvertical = false;
                        if (spawnpoint.GetComponent<SpawnPointValues>().directionleft)
                        {
                            enemy.GetComponent<Bouncer>().directionleft = true;
                        }
                        else
                        {
                            enemy.GetComponent<Bouncer>().directionleft = false;
                        }
                    }

                }
                Instantiate(enemy, spawnpoint.transform.position, Quaternion.identity);
                spawntimestamp = Time.time + spawnrate + randomVariance;
            }
        }


    }
    private GameObject RandomSpawnPoint()
    {
        int randompoint = Random.Range(0, 5);
        return spawnpoints[randompoint];
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
