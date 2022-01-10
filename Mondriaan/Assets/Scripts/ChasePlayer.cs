using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 enemyPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            playerPos = player.transform.position;
            enemyPos = transform.position;
            transform.position = new Vector3(enemyPos.x + (playerPos - enemyPos).normalized.x * Time.deltaTime, enemyPos.y, enemyPos.z);
        }
    }
}
