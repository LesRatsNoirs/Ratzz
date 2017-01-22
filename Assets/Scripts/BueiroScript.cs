using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BueiroScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            playerScript.FoundSewer(collision.gameObject);
            
        }
        if(collision.gameObject.tag == "Mouse") {
            Debug.Log("Mouse");
            Mouse m = collision.GetComponent<Mouse>();
            m.removeMouse();

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            
            playerScript.FoundSewer(null);
        }
        
    }
}
