using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    public bool CanCreateHere;


	// Use this for initialization
	void Start () {
        CanCreateHere = true;
        
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Mouse") {
            WaitToSpawn();
            CanCreateHere = true;
        }
    }

    IEnumerator WaitToSpawn() {
        yield return new WaitForSeconds(2);
    }

}
