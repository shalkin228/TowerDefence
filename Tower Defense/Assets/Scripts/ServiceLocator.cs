using System.Collections.Generic;
using System;

namespace TowerDefence
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object>
            _services = new Dictionary<Type, object>();

        public static void Register<T>(T serviceInstance)
        {
            _services[typeof(T)] = serviceInstance;
        }

        public static void Unregister<T>()
        {
            _services.Remove(typeof(T));
        }

        public static T Get<T>()
        {
            return (T)_services[typeof(T)];
        }

        public static bool Contains<T>() 
        { 
            return _services.ContainsKey(typeof(T));
        }

        public static void Reset()
        {
            _services.Clear();
        }

    }
}
