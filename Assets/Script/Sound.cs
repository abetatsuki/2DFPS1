using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource cAudioSource;
    public AudioSource bAudioSource;
    // Start is called before the first frame update
    void Start()
    {
      cAudioSource.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.score == 100)
        {
           cAudioSource.Play();

        }
    }
}
