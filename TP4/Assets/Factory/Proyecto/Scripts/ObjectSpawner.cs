using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Factory _factory;
    [SerializeField] private Transform[] _transforms;

    public void SpawnObjectBush()
    {
        _factory.Create("Bush", _transforms[0]);
    }

    public void SpawnObjectTree()
    {
        _factory.Create("Tree", _transforms[1]);
    }

    public void SpawnObjectRock()
    {
        _factory.Create("Rock", _transforms[2]);
    }

}
