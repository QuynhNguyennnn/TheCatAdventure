using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMap3 : MonoBehaviour
{
    [Header("------------ Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [Header("------------ Audio Clip -------------")]
    public AudioClip background1;
    public AudioClip background2;

    [SerializeField]
    public GameObject change1;
    [SerializeField]
    public GameObject change2;

    bool check = false;

    void Start()
    {
        musicSource.loop = true;
        musicSource.clip = background1;
        musicSource.Play();
    }

    void Update()
    {
        if (change1 != null)
        {
            if (change1.GetComponent<BossZone>().Change() && check == false)
            {
                musicSource.clip = background2;
                musicSource.Play();
                check = true;
            }
        }

        if (change2 != null)
        {
            if (change2.GetComponent<TeleMap3ToMap4>().Change() && check == true)
            {
                musicSource.clip = background1;
                musicSource.Play();
                check = false;
            }
        }
    }
}
