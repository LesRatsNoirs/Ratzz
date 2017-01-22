using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;


//TODO Hiscore
//TODO TEMPO
//TODO Cr'editos
//TODO Bueiros




public class Mouse   : MonoBehaviour {

    private PlayerScript player;

    public string MouseType;


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

    public GameObject Bueiro;

    private void Awake() {
       
    }

    private void Start() {
        moveDirection = Vector3.right;
        player = GameObject.FindObjectOfType<PlayerScript>();
        
    }

    private Vector3 GetMoveToward() {

        Vector3 moveToward;
        if (Bueiro != null) {
            Debug.Log("Bueiro");
            moveToward = Bueiro.transform.position;
            range = 99;
            range2 = 99;
            stop = 0;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            previousMouse = null;
            return moveToward;
        }

        if (!isInPlayer && previousMouse == null) {
            moveToward = player.transform.position;
        }
        else {
            if (previousMouse != null && previousMouse != this) {
                moveToward = previousMouse.transform.position;
            }
            else {
                moveToward = player.transform.position;
            }
        }


        return moveToward;
    }


    void Update() {

        // 1
        Vector3 currentPosition = transform.position;
        // 2
        Vector3 moveToward = GetMoveToward();

        // 4
        moveDirection = moveToward - currentPosition;
        moveDirection.z = 0;
        moveDirection.Normalize();

        float distance = Vector3.Distance(transform.position, moveToward);

        Vector3 target = moveDirection * moveSpeed + currentPosition;

        if (distance <= range && distance > stop) {
            transform.position = Vector3.Slerp(currentPosition, target, Time.deltaTime);
            if (Bueiro != null) {
                player.AddMouseOnPlayer(this);
            }

            isInPlayer = true;
        }


        float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        //TODO: Place animation for mouse

        if (targetAngle > 45 && targetAngle < 135) {
            //Debug.Log("Mouse UP");

        }
        else if (targetAngle < -45 && targetAngle > -135) {
            //Debug.Log("Mouse Down");
        }
        else if (targetAngle < 45 && targetAngle > -135) {
            //Debug.Log("Mouse Left");
        }
        else if ((targetAngle > 135) || (targetAngle < -135)) {
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


    public void removeMouse() {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision) {
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
        Destroy(gameObject,2);
    }


}
