using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float xMin, xMax;
    public GameObject playerBullet;
    public GameObject bulletSpawn;
    public float fireRate;
    private float nextFire;


    public int playerLife;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(playerBullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            GetComponent<AudioSource>().Play();
        }


        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Input.mousePosition;
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(touchPos).x, -4.0f, 0.0f);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), -4.0f, 0.0f);
        }

    }
}
