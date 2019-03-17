using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Sprite goal = Resources.Load("goal", typeof(Sprite)) as Sprite;
            GameObject.Find("Player").GetComponent<PlayerContllore>().setStartMove(1);
            if(GetComponent<SpriteRenderer>().sprite == goal)
            {
                SceneContlloer.scenechenge(1);
            }
            Destroy(this.gameObject);
        }

    }
}
