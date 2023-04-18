using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance => s_Instance;

    protected static T s_Instance;

    protected virtual void OnDestroy() 
    {
        if(s_Instance == this)
        {
            s_Instance = null;
        }
    }

    private void Awake() 
    {
        if(s_Instance == null)
        {
            s_Instance = this as T;
        }
        else
        {
            Debug.LogError($"Instance of {typeof(T)} already exists!");
        }
    }

    private void OnValidate() 
    {
        gameObject.name = typeof(T).Name;
    }
}