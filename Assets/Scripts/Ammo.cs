using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    public float AmmoVelocity = 10;
    private Rigidbody2D Rb;
    public float rot;

    public float ammoDuration = 2f;

    // Use this for initialization
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Rb.velocity = transform.right * AmmoVelocity;
        transform.Rotate(new Vector3(0, 0, rot));
        Destroy(gameObject, ammoDuration);

    }

    private void OnCollisionBegin2D(Collision2D collision) {
        Destroy(gameObject);
    }
}