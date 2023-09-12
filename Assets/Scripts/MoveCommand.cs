using System;
using TMPro;
using UnityEngine;

namespace NinetySix
{
    public class MoveCommand : MonoBehaviour, ICommand
    {
        [SerializeField]
        private TMP_InputField _inputField;

        public void Execute(GameObject player)
        {
            player.transform.Translate(new Vector3(Convert.ToSingle(_inputField.text), 0, 0));
        }
    }
}