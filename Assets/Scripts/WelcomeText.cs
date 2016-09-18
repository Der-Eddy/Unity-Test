using UnityEngine;
using System.Collections;

namespace UnityTest
{
    public class WelcomeText : MonoBehaviour
    {
        public float removeWelcomeText;

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, removeWelcomeText);
        }
    }
}