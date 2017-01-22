using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    void Awake(){
        if (instance == null) {
            instance = this;
        } else {
            if (instance != this) {
                Destroy(gameObject);
            }
        }     
        DontDestroyOnLoad(gameObject);
    }

    void Start() {

    }

    public void StartGame() {
        //SceneManager.LoadScene("Game");
    }

    public void EndGame() {
        //TODO AddScore
        SceneManager.LoadScene("EndGame");
    }
    
}
