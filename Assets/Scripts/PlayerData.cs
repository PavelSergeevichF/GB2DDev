using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public Car Car { get; }
    public SubscriptionProperty<GameState> GameState { get; private set; }
    public IAnalyticTools Analytic { get; }
    public PlayerData()
    {
        Analytic = new UnityAnalyticTools();
        Car = new Car(1f);
        GameState = new SubscriptionProperty<GameState>();
        GameState.Value = global::GameState.None;
    }
}
