using System;
using System.Collections.Generic;
namespace Events
{
    public class GameEventManager
    {
        #region Singleton
        public static GameEventManager Instance
        {
            get
            {
                return instance ??= new GameEventManager();
            }
        }
        private static GameEventManager instance = default;
        #endregion

        public delegate void EventDelegate<T>(T e) where T : GameEvent;
        private delegate void EventDelegate(GameEvent e);

        private Dictionary<Type, EventDelegate> eventsDictionary;

        public GameEventManager()
        {
            eventsDictionary = new Dictionary<Type, EventDelegate>();
        }

        public void AddListener<T>(EventDelegate<T> listener) where T : GameEvent
        {
            EventDelegate eve = (e) => listener((T)e);
            if (!eventsDictionary.TryAdd(typeof(T), eve))
            {
                eventsDictionary[typeof(T)] += eve;
            }
        }
        public void RemoveListener<T>(EventDelegate<T> listener) where T : GameEvent
        {
            EventDelegate eve = (e) => listener((T)e);
            eventsDictionary.TryGetValue(typeof(T), out var _event);
            if (_event != null)
            {
                _event -= eve;
            }
        }
        public void RemoveAllListener<T>() where T : GameEvent
        {
            eventsDictionary.Remove(typeof(T));
        }
        public void TriggerEvent(GameEvent e)
        {
            eventsDictionary.TryGetValue(e.GetType(), out var _event);
            _event?.Invoke(e);
        }
    }
    public class GameEvent
    {

    }
    public class PlayerDeathEvent : GameEvent
    {
        public int item;

        public PlayerDeathEvent(int item)
        {
            this.item = item;
        }
    }
}