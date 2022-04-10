using UnityEngine;

public class Root:MonoBehaviour
{
    [SerializeField]
    private Transform _uiRoot;
    private MainController _mainController;
    private void Start()
    {
        var model = new PlayerData();
        _mainController = new MainController(model, _uiRoot);
    }
    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}