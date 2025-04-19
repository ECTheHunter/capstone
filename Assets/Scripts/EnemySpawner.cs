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
    [SerializeField] private float spawnratevariance;
    [SerializeField] private float diffucultyrate;
    [SerializeField] private GameObject regularenemy;
    [SerializeField] private GameObject bouncer;
    [SerializeField] private GameObject chomper;
    [SerializeField] private GameObject l_r;
    [SerializeField] List<GameObject> spawnpoints = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
