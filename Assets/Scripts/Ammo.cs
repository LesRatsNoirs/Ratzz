using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    public float AmmoVelocity =10;
    private Rigidbody2D Rb;

    public float duration = 2f;
    private float currentTime;

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody2D>();
        currentTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
        Rb.velocity = transform.right * AmmoVelocity;
        Debug.Log(transform.forward);
	}

    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }
}
