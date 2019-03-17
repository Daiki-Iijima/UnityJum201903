using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPC : MonoBehaviour {

    private Renderer targetRenderer; // 判定したいオブジェクトのrendererへの参照

    [SerializeField]
    private float moveSpeed = 0.1f;

    private bool start;

    public void setStart(bool start)
    {
        this.start = start;
    }

    void Start()
    {
        start = false;
        targetRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (start)
        {
            this.transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
    }


    void OnBecameVisible()
    {
        // 表示されるようになった時の処理
        Debug.Log("画面に表示されてるよ");
    }
    void OnBecameInvisible()
    {
        SceneContlloer.scenechenge(1);
    }

}
