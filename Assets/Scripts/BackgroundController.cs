using UnityEngine;

public class BackgroundController : BaseController
{
    private TapeBackgroundView _background;
    public BackgroundController ()
    {
        var prefab = ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = "Prefabs/background" });
        var go = GameObject.Instantiate(prefab);
        AddGameObject(go);
        _background = go.GetComponent<TapeBackgroundView>();
    }
}