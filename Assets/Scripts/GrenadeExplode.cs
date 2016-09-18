using UnityEngine;
using System.Collections;

namespace UnityTest
{
    public class GrenadeExplode : MonoBehaviour
    {
        public float blastRadius;
        public float explosionPower;
        public LayerMask explosionLayer;

        Collider[] hitColliders;
        AudioSource audio;
        Renderer renderer;
        float destroyTime = 5f;

        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            audio = GetComponent<AudioSource>();
            renderer = GetComponent<MeshRenderer>();
        }

        void OnCollisionEnter(Collision col)
        {
            ExplosionWork(col.contacts[0].point);
            audio.Play();
            renderer.enabled = false;
            Destroy(gameObject, 1f);
        }

        void ExplosionWork(Vector3 explosionPoint)
        {
            hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayer);

            foreach(Collider hit in hitColliders)
            {
                if(hit.GetComponent<NavMeshAgent>() != null)
                {
                    hit.GetComponent<NavMeshAgent>().enabled = false;
                }

                if(hit.GetComponent<Rigidbody>() != null)
                {
                    hit.GetComponent<Rigidbody>().isKinematic = false;
                    hit.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
                }

                if (hit.CompareTag("Enemy"))
                {
                    Destroy(hit.gameObject, destroyTime);
                }
            }
        }
    }
}