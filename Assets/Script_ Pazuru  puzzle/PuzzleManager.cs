using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : Singleton<PuzzleManager>
{
    [SerializeField]
    private float moveSpped;

    [SerializeField]
    private float moveError;

    public Transform nullPos;

    private bool move;

    private bool gameStart;

    private Transform movePos;

    private Vector3 target;

    private Vector3 nullTarget;

    public void setMovePos(Transform movePos)
    {
        this.movePos = movePos;
        target = movePos.localPosition;
        nullTarget = nullPos.localPosition;
    }

    public void setMove(bool move)
    {
        this.move = move;
    }
    public bool getMove()
    {
        return move;
    }
    public bool getGameStart()
    {
        return gameStart;
    }



    // Use this for initialization
    void Start()
    {
        gameStart = false;
        move = false;
        int nullNum = 0;

        foreach (Transform child in this.transform)
        {

            if (child.GetComponent<PuzzleContllore>().getIsNull())
            {
                nullPos = child;
                nullNum++;
            }
        }

        if (nullNum >= 2) { Debug.LogError("空パネルが二つあります"); return; }
        if (nullNum <= 0) { Debug.LogError("空パネルがありません"); return; }
        GetMovePanel();

    }

    void Update()
    {
        if (move)
        {
            movePos.localPosition = Vector3.Lerp(movePos.localPosition, nullTarget, Time.deltaTime * moveSpped);
            nullPos.localPosition = Vector3.Lerp(nullPos.localPosition, target, Time.deltaTime * moveSpped);
            float num = Math.Abs(nullPos.localPosition.x - target.x) + Math.Abs(nullPos.localPosition.y - target.y);
            if (num <= 0.005)
            {
                nullPos.localPosition = target;
                movePos.localPosition = nullTarget;
                move = false;
                GetMovePanel();
            }
        }
    }



    public void GetMovePanel()
    {
        foreach (Transform child in this.transform)
        {
            child.GetComponent<PuzzleContllore>().setIsMoving(false);
            if (child.GetComponent<PuzzleContllore>().getIsNull())
            {
                nullPos = child;
            }

        }

        Transform upPso = null;
        Transform downPso = null;
        Transform rightPso = null;
        Transform leftPso = null;

        foreach (Transform child in this.transform)
        {

            if (child != nullPos)
            {
                float x = Math.Abs(nullPos.localPosition.x - child.localPosition.x);
                if (x <= moveError)
                {

                    if (nullPos.localPosition.y < child.localPosition.y)
                    {
                        if (upPso == null)
                        {
                            upPso = child;
                        }
                        float num = Math.Abs(child.localPosition.y - nullPos.localPosition.y);
                        float num2 = Math.Abs(upPso.localPosition.y - nullPos.localPosition.y);
                        if (num <= num2) upPso = child;
                    }
                    else
                    {
                        if (downPso == null)
                        {
                            downPso = child;
                        }

                        float num = Math.Abs(child.localPosition.y - nullPos.localPosition.y);
                        float num2 = Math.Abs(downPso.localPosition.y - nullPos.localPosition.y);
                        if (num <= num2) downPso = child;
                    }
                }
                float y = Math.Abs(nullPos.localPosition.y - child.localPosition.y);
                if (y <= moveError)
                {

                    if (nullPos.localPosition.x < child.localPosition.x)
                    {

                        if (rightPso == null)
                        {
                            rightPso = child;
                        }
                        float num = Math.Abs(child.localPosition.x - nullPos.localPosition.x);
                        float num2 = Math.Abs(rightPso.localPosition.x - nullPos.localPosition.x);
                        if (num <= num2) rightPso = child;
                    }
                    else
                    {
                        if (leftPso == null)
                        {
                            leftPso = child;
                        }
                        float num = Math.Abs(child.localPosition.x - nullPos.localPosition.x);
                        float num2 = Math.Abs(leftPso.localPosition.x - nullPos.localPosition.x);
                        if (num <= num2) leftPso = child;
                    }
                }
            }
        }

        if (upPso != null)
            upPso.GetComponent<PuzzleContllore>().setIsMoving(true);
        if (downPso != null)
            downPso.GetComponent<PuzzleContllore>().setIsMoving(true);
        if (rightPso != null)
            rightPso.GetComponent<PuzzleContllore>().setIsMoving(true);
        if (leftPso != null)
            leftPso.GetComponent<PuzzleContllore>().setIsMoving(true);

        if (downPso == null && rightPso == null && leftPso == null && upPso != null)
        {
            gameStart = true;
        }

    }
}
