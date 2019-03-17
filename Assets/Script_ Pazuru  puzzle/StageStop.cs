using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStop : MonoBehaviour
{

    private PlayerContllore playerContllore;

    private GameObject screen;
    private Sprite goal;
    private Sprite start;
    private bool create;

    // Use this for initialization
    void Start()
    {
        create = false;
        screen = Resources.Load("screen", typeof(GameObject)) as GameObject;
        goal = Resources.Load("goal", typeof(Sprite)) as Sprite;
        start = Resources.Load("start", typeof(Sprite)) as Sprite;

        screen.GetComponent<SpriteRenderer>().sprite = start;
        Instantiate(screen);
        playerContllore = GameObject.Find("Player").GetComponent<PlayerContllore>();
        playerContllore.setStartMove(0);
    }

    void Update()
    {
        if (playerContllore.getNewGool() && !create)
        {
            create = true;
            screen.GetComponent<SpriteRenderer>().sprite = goal;
            Instantiate(screen);
        }
    }
}
