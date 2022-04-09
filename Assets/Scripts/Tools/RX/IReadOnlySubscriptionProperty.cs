using System;

public interface IReadOnlySubscriptionProperty <T>
{
    T Value { get; }

    private void SubscribeOnChange(Action<T> subscriptionAction);
    private void UnSubscriptionOnChange(Action<T> unsubscriptionAction);
}
