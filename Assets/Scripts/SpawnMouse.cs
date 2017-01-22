using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMouse : MonoBehaviour {
     
    public int CurrentMouses = 0;
    private float RandomNumber;
    public GameObject Mouse1;
    public GameObject Mouse2;
    public GameObject Mouse3;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Spawn();
	}

    public void Spawn() {
        RandomNumber = Random.Range(0f, 10f);
    }
}
