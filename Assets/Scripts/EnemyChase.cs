using UnityEngine;
using System.Collections;

namespace UnityTest
{
    public class EnemyChase : MonoBehaviour
    {
        public LayerMask detectionLayer;

        Transform cacheTransform;
        NavMeshAgent cacheNavMeshAgent;
        Collider[] hitCollider;
        float checkRate;
        float nextCheck;
        float detectionRadius = 50f;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckIfPlayerInRange();
        }

        void SetInitialReferences()
        {
            cacheTransform = transform;
            cacheNavMeshAgent = GetComponent<NavMeshAgent>();
            checkRate = Random.Range(0.8f, 1.2f);
        }

        void CheckIfPlayerInRange()
        {
            if (Time.time > nextCheck && cacheNavMeshAgent.enabled == true)
            {
                nextCheck = Time.time + checkRate;

                hitCollider = Physics.OverlapSphere(cacheTransform.position, detectionRadius, detectionLayer);

                if(hitCollider.Length > 0)
                {
                    cacheNavMeshAgent.SetDestination(hitCollider[0].transform.position);
                }
            }
        }
    }
}