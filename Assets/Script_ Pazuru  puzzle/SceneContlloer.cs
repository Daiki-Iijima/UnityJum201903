using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContlloer : MonoBehaviour
{

    private Transform nullPanel;
    private Vector3 nullpos;

    void Start()
    {
        nullPanel = GameObject.Find("Board").GetComponent<PuzzleManager>().nullPos;
        nullpos = nullPanel.transform.localPosition;
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
                if (child.transform.localPosition == nullpos)
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

}
