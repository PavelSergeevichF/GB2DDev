using UnityEngine;

public class InputController : BaseController
{
    private BaseInputView _inputView;
    public InputController()
    {
        var prefab = ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = "Prefabs/StickControl" });
        var go = GameObject.Instantiate(prefab);
        AddGameObject(go);
        go.GetComponent<BaseInputView>();
    }
}
