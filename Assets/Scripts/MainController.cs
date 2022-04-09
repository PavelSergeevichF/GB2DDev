using System;
public class MainController : BaseController
{
    private readonly PlayerData _model;
    private BaseController _currentController;
    public MainController(PlayerData model)
    {
        _model = model;
        _model.GameState.SubscribeOnChange(OnGameModelChanged);
    }

    private void OnGameModelChanged(GameState state)
    {
        switch(state)
        {
            case GameState.None:
                break;
            case GameState.Menu:
                break;
            case GameState.Game:
                break;
        }
    }
    protected override void OnDispose()
    {
        _model.GameState.UnSubscriptionOnChange(OnGameModelChanged);
        base.OnDispose();
    }
}
