using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrapText : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    int numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        GetComponent<Text>().text = "You fell for it Traveler! NOW YOU SHALL SUFFER!\nEnemies Left: " + numberOfEnemies;
    }
}
