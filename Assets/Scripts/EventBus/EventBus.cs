using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventBus
{
    private Dictionary<Type, List<EventHandler>> _subscriberByType;

    public EventBus()
    {
        _subscriberByType = new Dictionary<Type, List<EventHandler>>();
    }

    //Поиск по типу и добавление в словарь
    public void Subscrive<T>(EventHandler eventHandler) where T: EventArgs
    {
        var type = typeof(T);
        if (!_subscriberByType.TryGetValue(type, out var subscribers))
        {
            _subscriberByType.Add(type, new List<EventHandler>());
        }
        
        _subscriberByType[type].Add(eventHandler);
    }

    //Поиск по типу и удаление из словаря
    public void Unsubscribe<T>(EventHandler eventHandler) where T : EventArgs
    {
        var type = typeof(T);
        if (_subscriberByType.TryGetValue(type, out var subscribers))
        {
            _subscriberByType[type].Remove(eventHandler);
        }
    }

    public void Publish(object sender, EventArgs eventArgs)
    {
        if (_subscriberByType.TryGetValue(eventArgs.GetType(), out var subscribers))
        {
            foreach (var subscriber in subscribers)
            {
                subscriber(sender, eventArgs);
            }
        }
    }
}
