using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private GameObject sound;

    // Use this for initialization
    void Start () {

        sound = Resources.Load("Sound", typeof(GameObject)) as GameObject;
        if (!GameObject.Find("Sound(Clone)"))
        {
            Instantiate(sound);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
