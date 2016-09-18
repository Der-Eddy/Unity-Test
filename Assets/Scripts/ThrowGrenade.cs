using UnityEngine;
using System.Collections;

namespace UnityTest
{
    public class ThrowGrenade : MonoBehaviour
    {
        public GameObject grenadePrefab;
        public float propulsionForce;

        Transform cacheTransform;
        AudioSource audio;
        //GameObject parentGameobject;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SpawnGrenade();
            }
        }

        void SetInitialReferences()
        {
            cacheTransform = transform;
            audio = GetComponent<AudioSource>();
            //parentGameobject = gameObject.transform.parent.gameObject;
        }

        void SpawnGrenade()
        {
            GameObject grenade = (GameObject) Instantiate(grenadePrefab, cacheTransform.TransformPoint(0, 0, 0.5f), cacheTransform.rotation);
            grenade.GetComponent<Rigidbody>().AddForce(cacheTransform.forward * propulsionForce, ForceMode.Impulse);
            Destroy(grenade, 10f);
            audio.Play();
        }

        void RotateWeapon()
        {
            //Not today ...
        }
    }
}