using UnityEngine;

/// <summary>
/// A singleton whose lifetime is the same as the application lifetime
/// </summary>
/// <typeparam name="T"> Singleton behaviour </typeparam>
public abstract class GlobalSingleton<T> : Singleton<T> where T : GlobalSingleton<T>
{
    protected override void OnInstance()
    {
        if(s_Instance == null)
        {
            s_Instance = this as T;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

/// <summary>
/// A singleton whose lifetime is dependent on external factors
/// </summary>
/// <typeparam name="T"> Singleton behaviour </typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance
    {
        get
        {
            if(s_Instance == null)
            {
                T instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.LogWarning($"No instance of {typeof(T)} was found, creating a new object");
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
                instance.OnInstance();
            }
            return s_Instance;
        }
    }
    
    protected static T s_Instance;

    protected virtual void OnDestroy() 
    {
        if(s_Instance == this)
        {
            s_Instance = null;
        }
    }

    protected virtual void OnInstance()
    {
        Debug.Log($"Creating Singleton of type {typeof(T)}");
        if(s_Instance == null)
        {
            s_Instance = this as T;
            Init();
        }
        else
        {
            Debug.LogError($"Instance of {typeof(T)} already exists!");
        }
    }

    protected virtual void Init(){}

    private void OnValidate() 
    {
        gameObject.name = typeof(T).Name;
    }
}
