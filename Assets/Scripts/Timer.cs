using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float TimeLeft;
    public Text GuiText;
    public GameObject GM;

	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
        TimeLeft -= Time.deltaTime;
        GuiText.text = "Timer: " + TimeLeft.ToString("F2");
        if (TimeLeft <= 0) {
            GM.GetComponent<GameManager>().EndGame();
        }
	} 
}
