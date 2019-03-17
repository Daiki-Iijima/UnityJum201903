using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Player").GetComponent<PlayerContllore>().setStartMove(1);
            Destroy(this.gameObject);
        }

    }
}
