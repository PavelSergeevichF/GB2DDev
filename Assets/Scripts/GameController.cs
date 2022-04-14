public class GameController : BaseController
{
    private readonly PlayerData _model;
    private InputController _input;
    private CarController _car;
    private BackgroundController _background;

    public GameController(PlayerData model)
    {
        _model = model;
        var movement = new SubscriptionProperty<float>();
        _car = new CarController();
        _input = new InputController(movement);
        _background = new BackgroundController(movement);
    }
}
