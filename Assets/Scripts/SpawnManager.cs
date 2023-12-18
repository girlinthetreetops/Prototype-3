using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePf;
    public float interval = 2.0f;
    public float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObstacle", startDelay, interval);

    }

    private void InstantiateObstacle()
    {
        Instantiate(obstaclePf, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
