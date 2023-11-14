using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectWithDelay : MonoBehaviour
{
    Action onDestroy;
    [SerializeField] public bool _autoDestroyOnSpawn;
    [SerializeField] public float _delay;

    private void Start()
    {
        if(_autoDestroyOnSpawn)
        Execute(_delay);
    }

    public void Execute(float delay = 0)
    {
        Destroy(this.gameObject, delay);
        
    }

    private void OnDestroy()
    {
        onDestroy?.Invoke();
    }

    public void Subscribe(Action cb)
    {
        onDestroy += cb;
    }
}
