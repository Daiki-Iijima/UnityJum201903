using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelContllore : MonoBehaviour
{

    [SerializeField]
    public PanelTypeEnum.PanelType panelType;


    public PanelTypeEnum.PanelType GetPanelType { get { return panelType; } }

    [SerializeField]
    private bool isStartPanel;

    [SerializeField]
    private bool isGoolPanel;

    void Start()
    {
        if (panelType == PanelTypeEnum.PanelType.None)
        {
            //Debug.Log("値が設定されていません : " + this.gameObject.name);
            return;
        }

        if (isStartPanel)
        {
            GameObject.Find("Player").transform.position = this.transform.localPosition;
        }

    }

    // Update is called once per frame
    void Update()
    {


    }
}
