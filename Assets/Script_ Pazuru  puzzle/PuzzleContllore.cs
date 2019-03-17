using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleContllore : MonoBehaviour
{

    [SerializeField]
    private bool isNull;

    [SerializeField]
    private bool isMoving;


    public bool getIsNull()
    {
        return isNull;
    }

    public void setIsMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }


    void OnMouseOver()
    {
        if (!transform.parent.GetComponent<PuzzlelManager>().getMove())
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnSortiePointClick();
            }
        }
    }


    public void OnSortiePointClick()
    {
        if (isMoving)
        {

            transform.parent.GetComponent<PuzzlelManager>().setMovePos(this.transform);
            transform.parent.GetComponent<PuzzlelManager>().setMove(true);
        }

    }
}
