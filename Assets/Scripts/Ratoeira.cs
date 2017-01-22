using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: tocar audio quando morrer.
public class Ratoeira : MonoBehaviour {

    public AudioSource audioS;

    void Start() {
        audioS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player") {
            audioS.Play();
            //TODO Tirar Ratos
            Destroy(gameObject);
        }
    }
}