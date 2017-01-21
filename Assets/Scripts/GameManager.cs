using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static int Score = 0;
    public float espera = 3;

    public void Awake() {
        this.getInstance();

    }

    void Start() {
        GetComponent<SpawnMouse>().WhereToSpawn();
        GetComponent<SpawnMouse>().WhereToSpawn();
    }

    public static void Scoring(int score) {
        Score += score;
        Debug.Log("To com: " + Score + " pontos.");
    }

    // Singleton
    private void getInstance() {
        if(instance == null) {
            instance = this;
        } else {
            if(instance != this) {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
