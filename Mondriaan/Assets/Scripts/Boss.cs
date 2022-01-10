using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject enemyBullet;          // 보스 미사일
    public GameObject[] bulletSpawn;          // 미사일 생성위치
    public float fireRate;
    private float nextFire;
    public float bossLife;
    private GameManager1 gameManager;

    private void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("gamemanager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager1>();
        }
    }
    void FixedUpdate()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(enemyBullet, bulletSpawn[0].transform.position, bulletSpawn[0].transform.rotation);
            Instantiate(enemyBullet, bulletSpawn[1].transform.position, bulletSpawn[1].transform.rotation);
            Instantiate(enemyBullet, bulletSpawn[2].transform.position, bulletSpawn[2].transform.rotation);
            GetComponent<AudioSource>().Play();
        }

        if(bossLife <= 0)
        {
            gameManager.GameClear();
            Destroy(this.gameObject);
            
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("playerbullet"))
        {
            Destroy(collision.gameObject);
            bossLife--;
            Debug.Log("Boss Life : " + bossLife);
        }
    }
}
