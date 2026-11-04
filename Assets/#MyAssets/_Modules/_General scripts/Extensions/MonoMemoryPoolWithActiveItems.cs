using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MonoMemoryPoolWithActiveItems<T> : MonoMemoryPool<T> where T : Component
{
    public List<T> activeItems = new();

    protected override void OnSpawned(T item)
    {
        base.OnSpawned(item);
        activeItems.Add(item);
    }

    protected override void OnDespawned(T item)
    {
        base.OnDespawned(item);
        activeItems.Remove(item);
    }
}