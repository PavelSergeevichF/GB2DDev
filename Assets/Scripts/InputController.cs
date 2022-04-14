using JoostenProductions;
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputController : BaseController
{
    private readonly SubscriptionProperty<float> _movement;
    private BaseInputView _inputView;
    public InputController(SubscriptionProperty<float> movement)
    {
        _movement = movement;
        var prefab = ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = "Prefabs/MobileSingleStickControl" });
        var go = GameObject.Instantiate(prefab);
        AddGameObject(go);
        _inputView = go.GetComponent<BaseInputView>();
    }
    protected override void OnDispose()
    {
        _movement.Value = CrossPlatformInputManager.GetAxis("Horithontal");
    }

    private void OnUpdate()
    {
        throw new NotImplementedException();
    }
}
