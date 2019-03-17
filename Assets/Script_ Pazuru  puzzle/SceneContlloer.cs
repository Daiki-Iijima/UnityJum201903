using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContlloer : MonoBehaviour
{


    void Update()
    {
        gameStart();
    }

    public void reScenes()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }

    public void startStage()
    {
        Transform gamestage = GameObject.Find("Board").transform;
        foreach (Transform child in gamestage)
        {
            if(child.transform.localPosition == Vector3.zero)
            {
                SceneManager.LoadScene(child.GetComponent<StageNo>().stageNo);
            }
             
        }

    }

    void gameStart()
    {
        if (transform.GetComponent<PuzzlelManager>() != null)
        {
            if (transform.GetComponent<PuzzlelManager>().getGameStart())
                SceneManager.LoadScene(1);
        }
    }
}
