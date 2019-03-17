using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : MonoBehaviour
{

    private PlayerContllore playerContllore;

    // Use this for initialization
    void Start()
    { 
        playerContllore = GameObject.Find("Player").GetComponent<PlayerContllore>();
        playerContllore.setStartMove(0);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerContllore.setStartMove(1);
            Destroy(this.gameObject);
        }

    }
}
