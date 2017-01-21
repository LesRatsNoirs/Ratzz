using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = 3;
        
        
        Debug.Log("Position: "+ transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void move() {
        
    }
}
