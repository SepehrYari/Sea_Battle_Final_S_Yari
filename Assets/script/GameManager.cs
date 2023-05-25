using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;// for respawning
    [SerializeField] private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y <= -20)
        {
            
            Player.transform.position = SpawnPoint.transform.position;
        }
    }
}
