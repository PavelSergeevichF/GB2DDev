using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : IDisposable
{
    private List<GameObject> _gameObject = new List<GameObject>();
    private List<BaseController> _controller = new List<BaseController>();
    private bool _isDisposed = false;

    protected void AddGameObject(GameObject gameObject)
    {
        _gameObject.Add(gameObject);
    }
    protected void AddController(BaseController controller )
    {
        _controller.Add(controller);
    }
    protected virtual void OnDispose()
    { }
    public void Dispose()
    {
        if (_isDisposed)
            return;
        OnDispose();
        foreach(var go in _gameObject)
        {
            GameObject.Destroy(go);
        }
        _gameObject.Clear();
        foreach(var controller in _controller)
        {
            controller.Dispose();
        }
        _controller.Clear();
    }
}
