using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rato : MonoBehaviour {

    public GameObject playerObject;
    private PlayerScript player;



    Transform target; //the enemy's target
    int moveSpeed = 3; //move speed
    int rotationSpeed = 3; //speed of turning
    float range =3;
    float range2 = 3;
    float stop = 1f;

    private Rigidbody2D rb;

    Transform transform;


    public int MaxVelocity = 200;

    void Awake() {
       
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        transform = rb.transform;
    }

    void Update() {
       
        if (playerObject == null) return;
        target = playerObject.transform;

        //rotate to look at the player
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= range2 && distance >= range) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
        }


        else if (distance <= range && distance > stop) {

            //move towards the player
           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);

           transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (distance <= stop) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
        }

    }
}
     