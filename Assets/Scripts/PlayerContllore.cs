using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContllore : MonoBehaviour
{

    public PanelTypeEnum.PanelType nextMoveType;

    public bool nowMoving;

    [SerializeField]
    private float moveSpeed = 0;

    private float movedLength = 0;

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
                        nowMoving = true;
                    }
                    break;
                case PanelTypeEnum.PanelType.left:
                    {
                        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + 90f);
                        nowMoving = true;
                    }
                    break;
                case PanelTypeEnum.PanelType.right:
                    {
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
                        movedLength += (transform.up * Time.deltaTime * moveSpeed * startMove).y;
                        this.transform.position += transform.up * Time.deltaTime * moveSpeed * startMove;

                        if (movedLength >= 0.15f)
                        {

                            nowMoving = false;
                            movedLength = 0;
                        }
                    }
                    break;
            }


        }
       

    }
}
