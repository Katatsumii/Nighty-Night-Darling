using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PuzzleSound : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void AudioPlay()
    {
        audio.Play();
    }
}
