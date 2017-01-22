using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


//TODO Hiscore
//TODO TEMPO
//TODO Cr'editos
//TODO Bueiros




public class Mouse   : MonoBehaviour {

    public GameObject playerObject;
    private PlayerScript player;



    Transform target; //the enemy's target
    int moveSpeed = 3; //move speed
    int rotationSpeed = 3; //speed of turning
    float range = 3;
    float range2 = 3;
    float stop = 1f;

    public float Health = 100.0f;

    public Mouse previousMouse;

    private bool isInPlayer = false;


    public int MaxVelocity = 200;


    private Vector3 moveDirection;
    public float turnSpeed = 5;

    private void Awake() {
       

    }

    private void Start() {
        moveDirection = Vector3.right;
        player = playerObject.GetComponent<PlayerScript>();
    }

    void Update() {

        // 1
        Vector3 currentPosition = transform.position;
        // 2
        Vector3 moveToward;
        if (!isInPlayer && previousMouse == null) { 
            moveToward = playerObject.transform.position;
        } else {
            if(previousMouse != null && previousMouse != this) {
                moveToward = previousMouse.transform.position;
            } else {
                moveToward = playerObject.transform.position;
            }
        }

        // 4
        moveDirection = moveToward - currentPosition;
        moveDirection.z = 0;
        moveDirection.Normalize();

        float distance = Vector3.Distance(transform.position, moveToward);

        Vector3 target = moveDirection * moveSpeed + currentPosition;

        if (distance <= range && distance > stop) {
            transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
            player.AddMouseOnPlayer(this);
            
            isInPlayer = true;
        }


        float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        
        //TODO: Place animation for mouse

        if(targetAngle > 45 && targetAngle < 135) {
            //Debug.Log("Mouse UP");
            
        } else if (targetAngle < -45 && targetAngle > -135) {
            //Debug.Log("Mouse Down");
        } else if(targetAngle < 45 && targetAngle > -135) {
            //Debug.Log("Mouse Left");
        } else if((targetAngle > 135) || (targetAngle < -135 )){ 
            //Debug.Log("Mouse Right");
        }
}


    public IEnumerable PlayMusicAnimation() {
        Debug.Log("Play Song mouse!");

        transform.position = transform.position + new Vector3(0,1,0);
        yield return new WaitForSeconds(1);
        transform.position = transform.position + new Vector3(0, -1, 0);
        Debug.Log("NEXT!");
    }


    public void TakeDamage(float damageAmmount) {
        this.Health -= damageAmmount;
        if(Health <= 0) {
            //TODO: GAME OVER
        }
    }



    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy") {
            this.Flee();
        }

    }



    public void Flee() {
        Debug.Log("Flee");
        //TODO Play Animation mouse flee
        int x = new Random().Next(0, 1); 
        int y = new Random().Next(0, 1);
        int z = new Random().Next(0, 1);
        transform.position += new Vector3(x, y, z);
        Destroy(this);
    }


}
