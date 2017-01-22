using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: tocar audio quando virar
public class EnemyTire : MonoBehaviour {

    private Rigidbody2D Rb;
    public float MaxVelocity;
    public float TireRotation;

    void Start(){
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Rb.velocity = transform.up*MaxVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        MaxVelocity *= (-1);
    }
}
