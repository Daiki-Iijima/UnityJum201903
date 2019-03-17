using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    private GameObject sound;

    // Use this for initialization
    void Start () {
        if (!GameObject.Find("Sound(Clone)"))
        {
            Instantiate(sound);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
