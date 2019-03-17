using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContllore : MonoBehaviour
{

    public PanelTypeEnum.PanelType nextMoveType;

    public bool nowMoving;

    [SerializeField]
    private float moveSpeed = 0;

    private Vector3 movedLength;

    private Vector3 targetPos;

    private float startMove;

    private bool newGool;

    public void setStartMove(float startMove)
    {
        this.startMove = startMove;
    }

    public bool getNewGool()
    {
        return newGool;
    }

    // Use this for initialization
    void Start()
    {
        newGool = false;
        nowMoving = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (PanelManager.Instance.GetGoolPos(this.transform.position))
        {
            newGool = true;
        }

        if (!nowMoving)
        {
            //パネルを取得
            nextMoveType = PanelManager.Instance.GetJugePos(this.transform.position);

            switch (nextMoveType)
            {
                case PanelTypeEnum.PanelType.Straight:
                    {
                        targetPos = PanelManager.Instance.GetTargetTransform(transform.up);
                        nowMoving = true;
                    }
                    break;
                case PanelTypeEnum.PanelType.left:
                    {

                        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + 90f);

                        targetPos = PanelManager.Instance.GetTargetTransform(transform.up);

                        nowMoving = true;


                    }
                    break;
                case PanelTypeEnum.PanelType.right:
                    {
                        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z - 90f);

                        targetPos = PanelManager.Instance.GetTargetTransform(transform.up);

                        nowMoving = true;
                    }
                    break;
            }
        }

        if (nowMoving)
        {

            switch (nextMoveType)
            {
                case PanelTypeEnum.PanelType.Straight:
                    {
                        movedLength += (transform.up * Time.deltaTime * moveSpeed * startMove);
                        this.transform.position += transform.up * Time.deltaTime * moveSpeed * startMove;

                        if (targetPos.y < this.transform.position.y)
                        {
                            this.transform.position = targetPos;
                            targetPos = Vector3.zero;
                            nowMoving = false;
                            movedLength = Vector3.zero;
                        }
                    }
                    break;

                case PanelTypeEnum.PanelType.left:
                    {
                        movedLength += (transform.up * Time.deltaTime * moveSpeed * startMove);
                        this.transform.position += transform.up * Time.deltaTime * moveSpeed * startMove;

                        if (targetPos.x > this.transform.position.x)
                        {
                            this.transform.position = targetPos;
                            nowMoving = false;
                            movedLength = Vector3.zero;
                        }
                    }
                    break;

                case PanelTypeEnum.PanelType.right:
                    {
                        movedLength += (transform.up * Time.deltaTime * moveSpeed * startMove);
                        this.transform.position += transform.up * Time.deltaTime * moveSpeed * startMove;



                        if (targetPos.y > this.transform.position.y)
                        {
                            this.transform.position = targetPos;
                            nowMoving = false;
                            movedLength = Vector3.zero;
                        }
                    }
                    break;

            }


        }


    }
}
