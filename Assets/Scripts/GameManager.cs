using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;

    public static GameManager instance;
    public int playerIndex = 0;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinished;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinished;
    }

    void OnLevelFinished(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.ToUpper().Equals("GAMEPLAY"))
        {
            Instantiate(players[playerIndex]);
        }
    }


}
