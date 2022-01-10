using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private GameManager1 gameManager;
    public GameObject destorySoundPref;
    private PlayerScript player;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerScript>();
        }

        GameObject gameManagerObject = GameObject.FindWithTag("gamemanager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager1>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            player.playerLife--;
            Instantiate(destorySoundPref, Vector3.zero, Quaternion.identity);
            if (player.playerLife == 0)
            {
                Destroy(collision.gameObject);
                gameManager.GameOver();
            }

        }
    }

}
