using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public ScreenManager ScreenManager;
    public ParticleSystem Conf1;
    public ParticleSystem Conf2;
    private void Awake()
    {
        ScreenManager = FindObjectOfType<ScreenManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        ScreenManager.Win();
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Conf1.Play();
        Conf2.Play();
    }
}
