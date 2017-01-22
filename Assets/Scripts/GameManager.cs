using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instancia;

    void Awake(){
        Instancia = this;
    }

    void Start() {
        GetComponent<SpawnMouse>().WhereToSpawn();
        GetComponent<SpawnMouse>().WhereToSpawn();
        GetComponent<SpawnMouse>().WhereToSpawn();
        GetComponent<SpawnMouse>().WhereToSpawn();
        GetComponent<SpawnMouse>().WhereToSpawn();
        GetComponent<SpawnMouse>().WhereToSpawn();
        GetComponent<SpawnMouse>().WhereToSpawn();
        GetComponent<SpawnMouse>().WhereToSpawn();
    }
    
}
