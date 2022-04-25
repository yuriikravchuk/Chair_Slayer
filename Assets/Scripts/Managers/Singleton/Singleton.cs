using System;
using UnityEngine;
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                var instances = FindObjectsOfType<T>();
                var count = instances.Length;
                if (count == 0)
                    return _instance = new GameObject($"{typeof(T).Name}").AddComponent<T>();
                else
                    return _instance = instances[0];
            }
        }
    }
}