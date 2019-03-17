using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] sound;

    private static AudioSource[] sources;
    void Start()
    {
        // Sceneを遷移してもオブジェクトが消えないようにする
        DontDestroyOnLoad(this);

        for (int i = 0; i < sound.Length; i++)
        {
            gameObject.AddComponent<AudioSource>().clip = sound[i];
        }
        sources = gameObject.GetComponents<AudioSource>();
        sources[0].loop = true;
        sources[0].Play();
    }


    public static void PlaySound(int soundNumber)
    {
        sources[soundNumber].Play();
    }

}
