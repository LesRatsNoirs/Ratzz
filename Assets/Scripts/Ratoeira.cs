using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: tocar audio quando morrer.
public class Ratoeira : MonoBehaviour {

    public float AmmoVelocity =10;
    private Rigidbody2D Rb;
    public float rot;

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Rb.velocity = transform.right * AmmoVelocity;
        Debug.Log(transform.forward);
        transform.Rotate(new Vector3(0, 0, rot));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }
}