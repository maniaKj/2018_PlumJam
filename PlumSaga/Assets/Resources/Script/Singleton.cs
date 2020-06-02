using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> where T : new()
{
    private static readonly T m_Instance = new T();
    public static T Instance
    {
        get
        {
            return m_Instance;
        }
    }
}

public abstract  class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
{ 
    private static T s_Instance = null;
    public static T Instance
    {
        get
        {
            if(s_Instance == null)
            {
                s_Instance = FindObjectOfType<T>();
            }

            return s_Instance;
        }
    }

}
