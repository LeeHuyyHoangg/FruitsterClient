using System;
using System.Collections;
using UnityEngine;

namespace Script
{
    public class SingletonMonoBehavior<T>: MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    GetInstance();
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                GetInstance();
                // DontDestroyOnLoad(gameObject);
            }
            // else
            //     Destroy(gameObject);
        }

        private static void GetInstance()
        {
            _instance = (T)FindObjectOfType(typeof(T));
            if (_instance == null)
            {
                var newGo = new GameObject(typeof(T).Name, typeof(T));
                _instance = newGo.GetComponent<T>();
            }
        }

        public void RunAfterMillisSec(Action action, int millisSec)
        {
            Instance.StartCoroutine(InvokeAfterMillisSec(action, millisSec));
        }
        
        private IEnumerator InvokeAfterMillisSec(Action action, int millisSec)
        {
            yield return new WaitForSeconds(millisSec);
            action?.Invoke();
        }
    }
}