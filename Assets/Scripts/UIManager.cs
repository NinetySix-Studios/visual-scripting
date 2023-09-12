using System;
using NaughtyAttributes;
using UnityEngine;

namespace NinetySix
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private MoveCommand _moveXCommandPrefab;

        [SerializeField]
        private RotateCommand _rotateCommandPrefab;
        
        [SerializeField]
        private Transform _parent; // parent object where we'll instantiate the command items.

        public static Action<Transform> OnExecutionBlockTransformReadyEvent { get; set; } // event fired when UIManager starts
        
        private void Start()
        {
            // make sure there are no children in execution block
            foreach (Transform child in _parent)
                Destroy(child);
            
            OnExecutionBlockTransformReadyEvent?.Invoke(_parent);
        }

        [Button()]
        public void OnMoveXButtonClicked()
        {
            Instantiate(_moveXCommandPrefab, _parent);
        }

        [Button()]
        public void OnRotateButtonClicked()
        {
            Instantiate(_rotateCommandPrefab, _parent);
        }
    }

}