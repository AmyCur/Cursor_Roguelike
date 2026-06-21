using UnityEngine;

namespace Util{ 
    public abstract class MonoSingleton<T> : MonoBehaviour where T :MonoSingleton<T>{
        static T instance;
        public static T Instance{
            get{
                if(instance==null) return instance = GameObject.FindObjectOfType<T>();
                return instance;
            }
            protected set{
                instance=value;
            }
        }
    }
}