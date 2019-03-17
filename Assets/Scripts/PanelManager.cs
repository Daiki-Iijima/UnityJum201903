using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanelManager : Singleton<PanelManager>
{
    /// <summary>
    /// 自分の子オブジェクトにあるパネルを保存
    /// </summary>
	[SerializeField]
    private List<Transform> panelList = new List<Transform>();

    /// <summary>
    /// 向かっている対象のトランスフォーム
    /// </summary>
    private Vector3 targetTransform;

    // Use this for initialization
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            //子オブジェクトを取得
            panelList.Add(child);
        }

        if (panelList.Count <= 0) { Debug.Log("パネルが取得できませんでした"); return; }


    }

    /// <summary>
    /// どのパネルの上にいるか
    /// TODO : どう動かすかを返すといいかも
    /// </summary>
    /// <param name="pos">判定したい位置</param>
    /// <returns>パネルがあった場合パネルの名前が帰ってくる</returns>
    public PanelTypeEnum.PanelType GetJugePos(Vector3 pos)
    {
        foreach (Transform child in panelList)
        {
            if (child.localPosition == pos)
            {
                targetTransform = child.localPosition;
                return child.GetComponent<PanelContllore>().GetPanelType;
            }
        }

        return PanelTypeEnum.PanelType.None;
    }

    public Vector3 GetTargetTransform(Vector3 vectol)
    {
        // Debug.Log((int)vectol.x + ":" + (int)vectol.y + ":" + targetTransform);

        if ((int)vectol.x == 1) { targetTransform = new Vector3(targetTransform.x + 0.15f, targetTransform.y, targetTransform.z); Debug.Log("D"); return targetTransform; }
        if ((int)vectol.y == 1) { targetTransform = new Vector3(targetTransform.x, targetTransform.y + 0.15f, targetTransform.z); Debug.Log("A"); return targetTransform; }

        if ((int)vectol.x == -1) { targetTransform = new Vector3(targetTransform.x - 0.15f, targetTransform.y, targetTransform.z); Debug.Log("DD"); Debug.Log(vectol.x + ":" + vectol.y + ":" + targetTransform); return targetTransform; }
        if ((int)vectol.y == -1) { targetTransform = new Vector3(targetTransform.x, targetTransform.y - 0.15f, targetTransform.z); Debug.Log("AA"); Debug.Log(vectol.x + ":" + vectol.y + ":" + targetTransform); return targetTransform; }

        Debug.Log((int)vectol.x + ":" + (int)vectol.y + ":" + targetTransform);

        return targetTransform;
    }

    /// <summary>
    /// どのパネルの上にいるか
    /// </summary>
    /// <param name="pos">判定したい位置</param>
    /// <returns>パネルがあった場合パネルの名前が帰ってくる</returns>
    public bool GetGoolPos(Vector3 pos)
    {
        foreach (Transform child in panelList)
        {
            if (child.localPosition == pos)
            {
                return child.GetComponent<PanelContllore>().getIsGoolPanel();
            }
        }

        return false;
    }
}
