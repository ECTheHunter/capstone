using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float movespeed;
    [SerializeField] private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        path = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        path.maxSpeed = movespeed;
        path.destination = target.position;
    }
}
