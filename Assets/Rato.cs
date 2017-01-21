using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rato : MonoBehaviour {

    public GameObject playerObject;
    private PlayerScript player;

    private Rigidbody2D Rb;

    public int MaxVelocity = 200;

    // Use this for initialization
    void Start () {
        player = playerObject.GetComponent<PlayerScript>();
        //TODO RETIRAR ISSO DAQUI.

	}

    
	
	// Update is called once per frame
	void Update () {
        if (player.lastPositions == null || player.lastPositions.Count == 0) return;

        Vector2 pos = player.lastPositions.Peek();

        transform.position = pos;
  /**
   *       pos = pos.normalized;

        float MoveX = pos.x;
        float MoveY = pos.y;

        Rb = GetComponent<Rigidbody2D>();

        Rb.velocity = new Vector2(MoveX * MaxVelocity * Time.deltaTime, MoveY * MaxVelocity * Time.deltaTime);
        */
        /*
        if (MoveX != 0) {
            if (MoveX > 0) {
                Sr.sprite = SpriteLeft;
                Sr.flipX = true;
            }
            else {
                Sr.sprite = SpriteLeft;
                Sr.flipX = false;
            }
        }
        
        else {
        
        if (MoveY != 0) {
                if (MoveY > 0) {
                    Sr.sprite = SpriteUp;
                    Sr.flipX = false;
                }
                else {
                    Sr.sprite = SpriteDown;
                    Sr.flipX = false;
                }
            }
        }
        */

	}

}
