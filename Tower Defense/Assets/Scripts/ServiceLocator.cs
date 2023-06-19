using System.Collections.Generic;
using System;

namespace TowerDefence
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object>
            _services = new Dictionary<Type, object>();

        public static void Register<T>(object serviceInstance)
        {
            _services[typeof(T)] = serviceInstance;
        }

        public static T Get<T>()
        {
            return (T)_services[typeof(T)];
        }

        public static void Reset()
        {
            _services.Clear();
        }

    }
}
