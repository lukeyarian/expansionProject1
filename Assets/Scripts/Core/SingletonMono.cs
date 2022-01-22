using UnityEngine;

public class SingletonMono<TInstance> : MonoBehaviour where TInstance : SingletonMono<TInstance>
{
    public static TInstance Instance;
    public bool IsPersistant;

    public virtual void Awake()
    {
        if (IsPersistant)
        {
            if (!Instance)
            {
                Instance = this as TInstance;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance = this as TInstance;
        }
    }
}
