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
        if (!transform.parent.GetComponent<PuzzleManager>().getMove())
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
            Sound.PlaySound(3);
            transform.parent.GetComponent<PuzzleManager>().setMovePos(this.transform);
            transform.parent.GetComponent<PuzzleManager>().setMove(true);
        }

    }
}
