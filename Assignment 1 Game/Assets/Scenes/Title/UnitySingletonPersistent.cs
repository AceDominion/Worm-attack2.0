// Taken from http://redframe-game.com/blog/global-managers-with-generic-singletons/

using UnityEngine;

/* 
 * This class is a Singleton GameObject that will be lazily initialized when it is referenced for the first time.
 * It derives from MonoBehaviour allowing for all of the usual Unity systems to be used.
 * The GameObject is persistent and will not be destroyed when a new scene is loaded.
 * 
 * See the link above for more information and an explanation.
 * 
 * NOTE: A subclasses must pass in its own Type as the T parameter, this is so the singleton
 * can typecast the instance member variable to the corrent class.
 */

public class UnitySingletonPersistent<T> : MonoBehaviour
    where T : Component
{
    protected static T _instance;

    public static bool InstanceExists() { return _instance != null; }

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    //obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<T>();
                    obj.name = _instance.GetType().ToString();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}