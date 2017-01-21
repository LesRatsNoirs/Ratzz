using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static int Score = 0;

    public void Awake() {
        this.getInstance();

    }

    public static void Scoring(int score) {
        Score += score;
        Debug.Log("");
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
