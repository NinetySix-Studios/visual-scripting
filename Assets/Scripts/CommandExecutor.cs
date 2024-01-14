using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace NinetySix
{
    /// <summary>
    /// Executes a series of commands on a player game object.
    /// </summary>
    public class CommandExecutor : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player; // reference for the player object that we'll move

        private Transform _parent; // parent object where we'll read the command items from for execution.

        private void OnEnable()
        {
            // listens to UIManager, so when it's done initializing, we initialize our command executor references.
            UIManager.OnExecutionBlockTransformReadyEvent += InitializeReference; 
        }

        private void OnDisable()
        {
            UIManager.OnExecutionBlockTransformReadyEvent -= InitializeReference;
        }

        private void InitializeReference(Transform parent)
        {
            _parent = parent;
        }

        [Button()]
        public void StartExecuteCommands()
        {
            StartCoroutine(ExecuteCommands());
        }
        
        private IEnumerator ExecuteCommands()
        {
            foreach (Transform child in _parent)
            {
                if(child.TryGetComponent(out ICommand iCommand))
                {
                    iCommand.Execute(_player);
                }
                yield return new WaitForSeconds(1f); // Wait for 1 second
            }
        }
    }
}