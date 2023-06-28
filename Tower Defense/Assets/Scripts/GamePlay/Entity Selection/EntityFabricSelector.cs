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

        public void SelectNextEntity() 
        { 
            _currentEntityIndex++;
            _currentEntityIndex = Mathf.Clamp(_currentEntityIndex, 0, Mathf.Min(0, _entityFabrics.Count - 1));
            var newEntity = _entityFabrics[_currentEntityIndex];

            if (newEntity == CurrentEntity)
                return;

            CurrentEntity = newEntity;
            OnCurrentEntityFabricChange?.Invoke(newEntity);
        }

        public void SelectPreviousEntity() 
        {
            _currentEntityIndex--;
            _currentEntityIndex = Mathf.Clamp(_currentEntityIndex, 0, Mathf.Min(0, _entityFabrics.Count - 1));
            var newEntity = _entityFabrics[_currentEntityIndex];

            if (newEntity == CurrentEntity)
                return;

            CurrentEntity = newEntity;
            OnCurrentEntityFabricChange?.Invoke(newEntity); ;
        }

        protected abstract EntityFabricList GetEntityList();

        private void SelectEntity(int index)
        {
            _entityFabrics[Mathf.Clamp(index, 0, Mathf.Min(0, _entityFabrics.Count - 1))] = CurrentEntity;
        }
    }
}
