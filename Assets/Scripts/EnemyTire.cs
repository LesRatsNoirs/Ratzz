using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTire : MonoBehaviour {

    private SpriteRenderer Sr;
    private Rigidbody2D Rb;
    public float MaxVelocity;
    public float TireRotation;

    void Start(){
        Sr = GetComponent<SpriteRenderer>();
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Rb.velocity = new Vector2(MaxVelocity * Time.deltaTime, 0);
        transform.Rotate(new Vector3(0, 0, TireRotation));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        MaxVelocity *= (-1);
        TireRotation *= (-1);
    }
}
