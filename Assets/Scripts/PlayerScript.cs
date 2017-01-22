using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float MoveX;
    public float MoveY;
    public float MaxVelocity;
    private Rigidbody2D Rb;
    private SpriteRenderer Sr;
    public Sprite SpriteLeft;
    public Sprite SpriteDown;
    public Sprite SpriteUp;

    public float Score = 0.0f;


    public List<Mouse> mouseList;

    public float speed;

    public Animator animator;

    private Mouse currentLastMouse;




    // Use this for initialization
    void Start () {
        Sr = GetComponent<SpriteRenderer>();
        mouseList = new List<Mouse>();
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
                //animator.SetTrigger("Left");
                
            }
            else {
                Sr.sprite = SpriteLeft;
                Sr.flipX = false;
                //animator.SetTrigger("Left");
            }
        }
        else {
            if (MoveY != 0) {
                if (MoveY > 0) {
                    Sr.sprite = SpriteUp;
                    Sr.flipX = false;
                    //animator.SetTrigger("Up");
                }
                else {
                    Sr.sprite = SpriteDown;
                    Sr.flipX = false;
                    //animator.SetTrigger("Down");
                }
            }
        }
    }

    //Isometric volume
    //TODO Retirar quando confirmado que nao 'e mais necessario
    /*
    private void OnTriggerEnter2D(Collider2D collision) {
        SpriteRenderer srPlayer = GetComponent<SpriteRenderer>();

        GameObject buildingObject = collision.gameObject;
        SpriteRenderer srBuilding = buildingObject.GetComponent<SpriteRenderer>();
        float positionY = srBuilding.transform.position.y;

        if (transform.position.y > positionY) {
            srPlayer.sortingOrder = srBuilding.sortingOrder - 1;
        }
        else if (transform.position.y > positionY) { // TOP
            srPlayer.sortingOrder = srBuilding.sortingOrder - 1;
        }
        else {
            srPlayer.sortingOrder = srBuilding.sortingOrder + 1;
        }
    }
    */
    void PlayMiceAudioAnimation() {
        foreach (Mouse m in mouseList) {
            m.PlayMusicAnimation();
        }
    }


    public void AddMouseOnPlayer(Mouse mouse) {
        Debug.Log("ADDING MOUSE");
        if (!mouseList.Contains(mouse)) {
            mouse.previousMouse = currentLastMouse;
            currentLastMouse = mouse;
            this.mouseList.Add(mouse);
        }
        //Debug.Log(mouse.name + " " + mouse.previousMouse.name);
    }

    public void FoundSewer(GameObject Sewer) {
        foreach (Mouse m in mouseList) {
            m.Bueiro = Sewer;

            if (m.MouseType == "Light") {
                Score += 10;
            }
            else if (m.MouseType == "Medium") {
                Score += 20;
            }
            else if (m.MouseType == "Large")
                Score += 30;
        }
        
    }


    public void LooseAllMices() {
        //Play ANIM Lost all mices
        foreach(Mouse m in mouseList) {
            m.Flee();
        }

        this.mouseList.Clear();
    }




    public static implicit operator PlayerScript(GameObject v) {
        throw new NotImplementedException();
    }
}
