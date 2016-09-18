using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityTest
{
    public class Spawner : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public int numberEnemies;

        float spawnRadius = 5;
        Vector3 spawnPosition;
        GameManager_EventMaster eventMasterScript;
        GameObject trapTextUI;
        GameObject wonTextUI;
        Light lightGameObject;

        void OnEnable()
        {
            SetInitialReferences();
            eventMasterScript.myGeneralEvent += SpawnObject;
        }

        void OnDisable()
        {
            eventMasterScript.myGeneralEvent -= SpawnObject;
        }

        void Update()
        {
            CountingEnemies();
        }

        void SetInitialReferences()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
            lightGameObject = GameObject.Find("Directional Light").GetComponent<Light>();
            trapTextUI = GameObject.Find("PanelTrap");
            trapTextUI.SetActive(false);
            wonTextUI = GameObject.Find("PanelWon");
            wonTextUI.SetActive(false);
        }

        void SpawnObject()
        {
            lightGameObject.type = LightType.Point;
            lightGameObject.color = Color.black;
            trapTextUI.SetActive(true);
            for (int i = 0; i < numberEnemies; i++)
            {
                spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
        }

        void CountingEnemies()
        {
            int numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (numberOfEnemies == 0 && trapTextUI.activeSelf)
            {
                wonTextUI.SetActive(true);
                trapTextUI.SetActive(false);
                lightGameObject.type = LightType.Directional;
                lightGameObject.color = new Color32(255, 244, 214, 255); //Default color
            }
        }
    }
}