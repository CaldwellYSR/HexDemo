using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{

    // TODO: Think about modifying this. We are taking integers as the 
    // Hex coordinate system but we might be sending messages unrelated
    // to hex coordinates. Maybe we make this generic and extend it
    // to accept integer arguments? Plz discuss

    // Keep up with dictionary of events
    private Dictionary<string, HexClickedEvent> eventDictionary;

    private static EventManager eventManager;

    // Make sure there is one and only one instance of event manager
    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, HexClickedEvent>();
        }
    }

    // Set up a listener for an Event name
    // If the event doesn't exist yet, create it
    public static void Listen(string eventName, UnityAction<int, int> listener)
    {
        HexClickedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new HexClickedEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    // Remove a listener... probably won't be used
    public static void StopListening(string eventName, UnityAction<int, int> listener)
    {
        if (eventManager == null) return;
        HexClickedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    // Trigger an event with a given key
    public static void Broadcast(string eventName, int x, int y)
    {
        HexClickedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(x, y);
        }
    }
}