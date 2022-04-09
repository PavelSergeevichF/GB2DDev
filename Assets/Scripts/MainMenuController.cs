using UnityEngine;

public class MainMenuController : BaseController
{
    private readonly PlayerData _model;
    private readonly Transform _uiRoot;

    public MainMenuController(PlayerData model, Transform uiRoot)
    {
        _model = model;
        _uiRoot = uiRoot;
    }
}
