using UnityEngine;
using System.Collections;

namespace UnityTest
{
    public class GameManager_EventMaster : MonoBehaviour
    {
        public delegate void GeneralEvent();
        public event GeneralEvent myGeneralEvent;

        AudioSource audio;

        void Awake()
        {
            audio = GetComponent<AudioSource>();
        }

        public void CallMyGeneralEvent()
        {
            if(myGeneralEvent != null)
            {
                myGeneralEvent();
                audio.Play();
            }
        }
    }
}