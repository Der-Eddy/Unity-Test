using UnityEngine;
using System.Collections;

namespace UnityTest
{
    public class WonMusic : MonoBehaviour
    {

        AudioSource audio;

        void Awake()
        {
            audio = GetComponent<AudioSource>();
        }

        void OnEnable()
        {
            audio.Play();
        }
    }
}