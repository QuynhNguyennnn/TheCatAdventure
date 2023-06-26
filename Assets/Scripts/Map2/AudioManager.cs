using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [Header("------------ Audio Clip -------------")]
    public AudioClip background1;
    public AudioClip background2;

    private void Start()
    {
        musicSource.clip = background1;
        musicSource.Play();
    }

}
