using UnityEngine;
using System.Collections;

namespace UnityTest
{
    public class TriggerCube : MonoBehaviour
    {
        GameManager_EventMaster eventMasterScript;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        void OnTriggerEnter(Collider other)
        {
            eventMasterScript.CallMyGeneralEvent();
            Destroy(gameObject);
        }

        void SetInitialReferences()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }
    }
}