using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixed : MonoBehaviour {

    public GameObject Ammo;
    public float TimeToFire;
    public bool CanFire;

    private void Start(){
        CanFire = true;
    }

	void Update () {
        if (CanFire) {
            Fire();
        }
	}

    void Fire() {
        CanFire = false;
        Instantiate(Ammo, transform.position, transform.rotation);
        StartCoroutine(WaitToFire());
    }

    IEnumerator WaitToFire() {
        Debug.Log("Aqui");
        yield return new WaitForSeconds(TimeToFire);
        CanFire = true;
    }
}
