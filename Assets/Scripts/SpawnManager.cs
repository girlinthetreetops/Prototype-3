using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePf;
    public float interval = 2.0f;
    public float startDelay = 1.0f;


    [SerializeField] private Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        InvokeRepeating("InstantiateObstacle", startDelay, interval);

    }



    private void InstantiateObstacle()
    {
        if (player.gameOver == false)
        {
            Instantiate(obstaclePf, transform.position, transform.rotation);
        }
    }
        
}
