using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SpawnMouse : MonoBehaviour {
    

     
    public int CurrentMouses = 0;
    private int Place;
    private int TypeMouse;
    public GameObject LightMouse;
    public GameObject MediumMouse;
    public GameObject LargeMouse;
    public static bool CanCreate = false;
    public GameObject[] SpawnPoint;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void WhereToSpawn() {
        do {
            Place = Random.Range(0, 13);
            CanCreate = SpawnPoint[Place].GetComponent<Point>().CanCreateHere;
        } while (!CanCreate);
        Spawn(Place);
    }

    public void Spawn(int num) {
        TypeMouse = Random.Range(0,100);
        if (TypeMouse <= 60) {
            Instantiate(LightMouse, SpawnPoint[num].transform.position, Quaternion.identity);
        } else {
            if (TypeMouse <= 90) {
                Instantiate(MediumMouse, SpawnPoint[num].transform.position, Quaternion.identity);
            }  else {
                Instantiate(LargeMouse, SpawnPoint[num].transform.position, Quaternion.identity);
            }
        }
        SpawnPoint[num].GetComponent<Point>().CanCreateHere = false;
    }

}
