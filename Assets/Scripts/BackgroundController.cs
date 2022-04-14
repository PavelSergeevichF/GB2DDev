using System;
using UnityEngine;

public class BackgroundController : BaseController
{
    private TapeBackgroundView _background;
    private readonly IReadOnlySubscriptionProperty<float> _movement;

    public BackgroundController (IReadOnlySubscriptionProperty<float> movement)
    {
        _movement = movement;
        var prefab = ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = "Prefabs/background" });
        var go = GameObject.Instantiate(prefab);
        AddGameObject(go);
        _background = go.GetComponent<TapeBackgroundView>();
        _background.Init(movement);
    }

}