using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelImageDataBase : MonoBehaviour
{

    public static Sprite GetTypeImage(PanelTypeEnum.PanelType _panelType)
    {
        Sprite retSprite = null;

        switch (_panelType)
        {
            case PanelTypeEnum.PanelType.Straight:
                {

                }
                break;
            case PanelTypeEnum.PanelType.goal:
                {

                }
                break;
            case PanelTypeEnum.PanelType.left:
                {

                }
                break;
            case PanelTypeEnum.PanelType.right:
                {

                }
                break;
            default:
                {

                }
                break;


        }

        return retSprite;

    }
}
