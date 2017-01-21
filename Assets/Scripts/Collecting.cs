using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour {

    public static int QuantityOfMouse = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void FreeMouse() {
        if (QuantityOfMouse == 0) {
            Debug.Log("Você não possui ratos para libertar.");
        } else {
            //Enviar os ratos.
            QuantityOfMouse = 0;
            Debug.Log("Quantidade Atual de ratos = " + QuantityOfMouse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Mouse") {
            if (QuantityOfMouse >= 5) {
                Debug.Log("Você tem muitos ratos.");
                Debug.Log("Quantidade Atual de ratos = " + QuantityOfMouse);
            } else {
                //Desativar o Rato
                //Chamar função que cria outro rato
                QuantityOfMouse++;
                Debug.Log("Quantidade Atual de ratos = " + QuantityOfMouse);
            }
        }
        
    }
}
