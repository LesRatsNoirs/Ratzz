using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCollisionSewer : MonoBehaviour {

    //public GameObject Player;

	// Use this for initialization
	void Start () {
        //Player.GetComponent<Collecting>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Sewer") {
            Collecting.FreeMouse();
        }
    }
}
