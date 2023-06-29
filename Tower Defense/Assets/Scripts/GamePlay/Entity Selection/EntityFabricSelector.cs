using System;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Input;

namespace TowerDefence.Gameplay.Entity
{
    public abstract class EntityFabricSelector
    {
        public event Action<EntityFabric> OnCurrentEntityFabricChange;
        public EntityFabric CurrentEntity { get; private set; }

        protected abstract bool _needLogs { get; }
        private List<EntityFabric> _entityFabrics => _entityFabricList.List;
        private EntityFabricList _entityFabricList;
        private int _currentEntityIndex = 0;

        public EntityFabricSelector()
        {
            _entityFabricList = GetEntityList();
            CurrentEntity = _entityFabrics[0];

            IInputService inputService = ServiceLocator.Get<IInputService>();
            inputService.OnNextEntityButton += SelectNextEntity;
            inputService.OnPreviousEntityButton += SelectPreviousEntity;
            if (inputService is StandartInputService standartInputService)
            {
                standartInputService.OnEntityIndexButton += SelectEntity;
            }
        }

        private void SelectNextEntity() 
        { 
            _currentEntityIndex++;
            _currentEntityIndex = Mathf.Clamp(_currentEntityIndex, 0, Mathf.Min(0, _entityFabrics.Count - 1));
            var newEntity = _entityFabrics[_currentEntityIndex];

            if (newEntity == CurrentEntity)
                return;

            CurrentEntity = newEntity;
            OnCurrentEntityFabricChange?.Invoke(newEntity);
            LogNewEntityFabric(CurrentEntity);
        }

        private void SelectPreviousEntity() 
        {
            _currentEntityIndex--;
            _currentEntityIndex = Mathf.Clamp(_currentEntityIndex, 0, Mathf.Min(0, _entityFabrics.Count - 1));
            var newEntity = _entityFabrics[_currentEntityIndex];

            if (newEntity == CurrentEntity)
                return;

            CurrentEntity = newEntity;
            OnCurrentEntityFabricChange?.Invoke(newEntity);
            LogNewEntityFabric(CurrentEntity);
        }

        protected abstract EntityFabricList GetEntityList();

        private void SelectEntity(int index)
        {
            CurrentEntity = _entityFabrics[Mathf.Clamp(index - 1, 0, Mathf.Max(0, _entityFabrics.Count - 1))];
            OnCurrentEntityFabricChange?.Invoke(CurrentEntity);

            LogNewEntityFabric(CurrentEntity);
        }

        private void LogNewEntityFabric(EntityFabric entityFabric)
        {
            if (_needLogs)
            {
                Debug.Log($"New entity fabric \"{entityFabric.Name}\" selected");
            }
        }
    }
}
