using System;
using UnityEngine;

public class MainController : BaseController
{
    private readonly PlayerData _model;
    private readonly Transform _uiRoot;
    private readonly IAdsShower ads;
    private BaseController _currentController;
    public MainController(PlayerData model, Transform uiRoot , IAdsShower ads)
    {
        _model = model;
        _uiRoot = uiRoot;
        this.ads = ads;
        _model.GameState.SubscribeOnChange(OnGameModelChanged);
        _model.GameState.Value = GameState.Menu;
    }

    private void OnGameModelChanged(GameState state)
    {
        switch(state)
        {
            case GameState.None:
                break;
            case GameState.Menu:
                ReplaceController(ref _currentController, CreatMenuController());
                break;
            case GameState.Game:
                ReplaceController(ref _currentController, CreatGameController());
                break;
        }
    }

    private GameController CreatGameController()
    {
        return new GameController(_model);
    }

    private void ReplaceController(ref BaseController controller, BaseController newController)
    {
        controller?.Dispose();
        controller = newController;
        AddController(controller);
    }
    private MainMenuController CreatMenuController()
    {
        return new MainMenuController(_model, _uiRoot, ads);
    }
    protected override void OnDispose()
    {
        _model.GameState.UnSubscriptionOnChange(OnGameModelChanged);
        base.OnDispose();
    }
}
