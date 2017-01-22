using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Class to sync all tracks by master
 */
public class AudioSync : MonoBehaviour {
    //set these in the inspector!
    public AudioSource master;
    public AudioSource slave;

    void Update() {
        
        float timeSinceLevel = Time.timeSinceLevelLoad;
        slave.PlayScheduled(timeSinceLevel + 10);
        slave.timeSamples = master.timeSamples;
    }
}