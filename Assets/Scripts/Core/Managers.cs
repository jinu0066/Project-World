using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static bool isQuit = false;
    static Managers instance;
    static Managers Instance
    {
        get
        {
            if (!isQuit)
            {
                Init();
            }
            return instance;
        }
    }

    #region Manager
    private GameManager game = new GameManager();

    public static GameManager Game { get => Instance.game; }
    #endregion

    void Start()
    {
        Init();
    }

    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            instance = go.GetComponent<Managers>();
        }

        instance.game.Init();
    }
}