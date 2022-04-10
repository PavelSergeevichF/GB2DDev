using UnityEngine;

public class CarController : BaseController
{
    private CarView _carView;
    public CarController()
    {
        var prefabs = ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = "Prefabs/Car" });
        var car =GameObject.Instantiate(prefabs);
        AddGameObject(car);
        _carView = car.GetComponent<CarView>();
    }
}
