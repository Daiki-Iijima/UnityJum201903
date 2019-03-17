using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTypeEnum : MonoBehaviour
{
    /// <summary>
    /// 床パネル進行方向
    /// </summary>
    public enum PanelType
    {
        None,//初期値

        Straight,//まっすぐ

        right,//右

        left,//左

        goal,//ゴール
    }
}
