using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContlloer : MonoBehaviour
{

    private Transform nullPanel;

    void Start()
    {
        nullPanel = GameObject.Find("Board").GetComponent<PuzzleManager>().nullPos;
    }

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
            if (nullPanel != child)
            {
                if (child.transform.localPosition == Vector3.zero)
                {
                    Sound.PlaySound(4);
                    SceneManager.LoadScene(child.GetComponent<StageNo>().stageNo);
                }
            }

        }

    }

    public static void scenechenge(int number)
    {
        SceneManager.LoadScene(number);
    }

    void gameStart()
    {
        if (transform.GetComponent<PuzzleManager>() != null)
        {
            if (transform.GetComponent<PuzzleManager>().getGameStart())
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
