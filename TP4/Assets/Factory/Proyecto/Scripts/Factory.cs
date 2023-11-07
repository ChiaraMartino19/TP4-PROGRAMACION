using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{

    [SerializeField] private Object[] _objects;

    private Dictionary<string, Object> _idToObject;


    private void Awake()
    {
        _idToObject = new Dictionary<string, Object>();

        foreach (var obj in _objects) 
        {
            _idToObject.Add(obj.Id, obj);
        }
    }
    public Object Create(string id, Transform objectPosition)
    {

        if (!_idToObject.TryGetValue(id, out var _object))
        {
            Debug.Log("Object with id: " + id + " does not exist");
        }

        return Instantiate(_object, objectPosition.transform);
    }
}
