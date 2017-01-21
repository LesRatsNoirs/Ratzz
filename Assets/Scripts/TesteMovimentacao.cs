using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteMovimentacao : MonoBehaviour {

    public float MoveX;
    public float MoveY;
    public float MaxVelocity;
    private Rigidbody2D Rb;
    private SpriteRenderer Sr;
    public Sprite SpriteLeft;
    public Sprite SpriteDown;
    public Sprite SpriteUp;


    // Use this for initialization
    void Start () {
        Sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");
        Rb = GetComponent<Rigidbody2D>();
        Rb.velocity = new Vector2(MoveX * MaxVelocity * Time.deltaTime, MoveY * MaxVelocity * Time.deltaTime);

        if (MoveX != 0) {
            if (MoveX > 0) {
                Sr.sprite = SpriteLeft;
                Sr.flipX = true;
            } else {
                Sr.sprite = SpriteLeft;
                Sr.flipX = false;
            }
        } else {
            if (MoveY != 0) {
                if (MoveY > 0) {
                    Sr.sprite = SpriteUp;
                    Sr.flipX = false;
                } else {
                    Sr.sprite = SpriteDown;
                    Sr.flipX = false;
                }
            }
        }
       
    }
   


    private void OnTriggerEnter2D(Collider2D collision) {

        SpriteRenderer srPlayer = GetComponent<SpriteRenderer>();

        GameObject buildingObject = collision.gameObject;
        SpriteRenderer srBuilding = buildingObject.GetComponent<SpriteRenderer>();
        float positionY = srBuilding.transform.position.y;

        //TODO Verificar o pivot se influencia
        //topo
        //Bottom
        if (transform.position.y > positionY) {
            srPlayer.sortingOrder = srBuilding.sortingOrder - 1;
        } else if(transform.position.y > positionY) { // TOP
            srPlayer.sortingOrder = srBuilding.sortingOrder - 1; 
        } else {
            srPlayer.sortingOrder = srBuilding.sortingOrder + 1;
        }
    }
}
