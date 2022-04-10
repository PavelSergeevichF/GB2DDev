using UnityEngine;

public class MainMenuController : BaseController
{
    private readonly PlayerData _model;
    private readonly Transform _uiRoot;

    public MainMenuController(PlayerData model, Transform uiRoot)
    {
        _model = model;
        _uiRoot = uiRoot;

        CreateView();
    }

    private void CreateView()
    {
        var prefab = ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = "Prefabs/mainMenu" });
        var go =GameObject.Instantiate(prefab, _uiRoot);
        var mineMenu = go.GetComponent<MainMenuView>();
        mineMenu.Init(StartGame);
        AddGameObject(go);
    }
    private MainMenuController CreateMenuController()
    {
        return new MainMenuController(_model, _uiRoot);
    }
    private GameController CreateGameController()
    {
        return new GameController(_model);
    }
    private void StartGame()
    {
        _model.GameState.Value = GameState.Game;
    }
}
