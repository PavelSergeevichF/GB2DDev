using UnityEngine;

public class Root:MonoBehaviour
{
    [SerializeField]
    private Transform _uiRoot;
    [SerializeField]
    private UnityAdsTools _ads;

    private MainController _mainController;
    private void Start()
    {
        var model = new PlayerData();
        _mainController = new MainController(model, _uiRoot, _ads);
    }
    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}