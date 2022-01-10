using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySound : MonoBehaviour
{
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
        Destroy(gameObject, audio.clip.length);
    }

}
