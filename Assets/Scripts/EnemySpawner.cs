using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float regularenemycost;
    [SerializeField] private float l_renemycost;
    [SerializeField] private float bouncerenemycost;
    [SerializeField] private float chomperenemycost;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnrate;
    [SerializeField] private float diffucultyrate;
    [SerializeField] List<GameObject> spawnpoints = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnEnemy()
    {

        GameObject enemyobj = Instantiate(enemy, transform.position, transform.rotation);
        yield return new WaitForSeconds(spawnrate);
        StartCoroutine(SpawnEnemy());

    }
}
