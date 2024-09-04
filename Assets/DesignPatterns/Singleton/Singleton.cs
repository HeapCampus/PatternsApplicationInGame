using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance;

    protected virtual void Awake()
    {
        if(Instance == null)
        {
            var objs = FindObjectsOfType(typeof(T)) as T[];
            if(objs.Length == 1)
            {
                Instance = objs[0];
            }
            else
            {
                Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                Instance = null;
            }
        }
    }
}


public class SingletonPersistent<T> : MonoBehaviour where T : Component
{
    public static T Instance;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            var objs = FindObjectsOfType(typeof(T)) as T[];
            if (objs.Length == 1)
            {
                Instance = objs[0];
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                Instance = null;
            }
        }
    }
}

public class LazySingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    GameObject newGo = new();
                    _instance = newGo.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }

}

