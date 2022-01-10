using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{
    public int scoreValue;
    private GameManager1 gameManager;

    public GameObject destorySoundPref;

    private PlayerScript player;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("player");
        if(playerObject != null)
        {
            player = playerObject.GetComponent<PlayerScript>();
        }

        GameObject gameManagerObject = GameObject.FindWithTag("gamemanager");
        if(gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager1>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 수정 전
        //if(collision.CompareTag("playerbullet") || collision.CompareTag("player"))
        //{
        //    gameManager.AddScore(scoreValue);
        //    Destroy(collision.gameObject);      // 상대방 오브젝트를 파괴함.
        //    //GameManager1.instance.AddScore(10);
        //    Instantiate(destorySoundPref, Vector3.zero, Quaternion.identity);
        //    Destroy(gameObject);                // 코드를 가지고 있는 오브젝트가 파괴됨.
        //}

        if (collision.CompareTag("player"))
        {
            player.playerLife--;
            Instantiate(destorySoundPref, Vector3.zero, Quaternion.identity);
            if(player.playerLife == 0)
            {
                Destroy(collision.gameObject);
                gameManager.GameOver();
            }

            //Destroy(collision.gameObject);
            //Instantiate(destorySoundPref, Vector3.zero, Quaternion.identity);
            //gameManager.GameOver();
            //Destroy(gameObject);
        }

        if (collision.CompareTag("playerbullet"))
        {
            gameManager.AddScore(scoreValue);
            Destroy(collision.gameObject);
            Instantiate(destorySoundPref, Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
