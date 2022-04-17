using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : BaseController
{
    private readonly PlayerData _model;
    private readonly Transform _uiRoot;
    private readonly IAdsShower ads;

    public MainMenuController(PlayerData model, Transform uiRoot, IAdsShower ads)
    {
        _model = model;
        _uiRoot = uiRoot;
        this.ads = ads;
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
        return new MainMenuController(_model, _uiRoot, ads);
    }
    private GameController CreateGameController()
    {
        return new GameController(_model);
    }
    private void StartGame()
    {
        _model.Analytic.SendMessage("progression", new Dictionary<string, object>() { { "event_name", "game_start" } });
        ads.ShowInterstitial();
        _model.GameState.Value = GameState.Game;
    }
}
