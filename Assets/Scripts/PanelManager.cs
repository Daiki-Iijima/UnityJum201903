using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    /// <summary>
    /// 自分の子オブジェクトにあるパネルを保存
    /// </summary>
	[SerializeField]
    private List<Transform> panelList = new List<Transform>();

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
                return child.GetComponent<PanelContllore>().GetPanelType;
            }
        }

        return PanelTypeEnum.PanelType.None;
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
