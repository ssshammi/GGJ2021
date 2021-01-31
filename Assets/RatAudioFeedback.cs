using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAudioFeedback : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ratLaugh;
    [SerializeField] private AudioClip ratRejection;
    public void RatComment(bool correctRat)
    {
        if (correctRat)
        {
            audioSource.PlayOneShot(ratRejection);
        }
        else
        {
            audioSource.PlayOneShot(ratLaugh);
        }
    }
}
