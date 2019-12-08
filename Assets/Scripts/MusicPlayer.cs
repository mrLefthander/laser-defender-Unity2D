using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //float musicPlayer = FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().volume;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        GetComponent<AudioSource>().volume = FindObjectOfType<GameSession>().GameVolume;
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
