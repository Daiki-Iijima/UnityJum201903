using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPC : MonoBehaviour {

    private Renderer targetRenderer; // 判定したいオブジェクトのrendererへの参照

    [SerializeField]
    private float moveSpeed = 0.1f;

    private bool start;

    private bool delete;

    public void setStart(bool start)
    {
        this.start = start;
    }

    void Start()
    {
        start = false;
        delete = false;
        targetRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (start)
        {
            this.transform.position += transform.right * Time.deltaTime * moveSpeed;

            
        }
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            if(delete)
            SceneContlloer.scenechenge(1);
        }
        else
        {
            delete = true;
        }

    }



}
