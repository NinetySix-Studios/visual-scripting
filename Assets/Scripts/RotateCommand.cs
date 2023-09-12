using TMPro;
using UnityEngine;

namespace NinetySix
{
    public class RotateCommand : MonoBehaviour, ICommand
    {
        [SerializeField]
        private TMP_InputField _inputField;

        public void Execute(GameObject player)
        {
            // parse the angle from the input field
            if (float.TryParse(_inputField.text, out float angle))
            {
                // rotate the player GameObject by the parsed angle
                player.transform.Rotate(0, angle, 0);
            }
        }
    }
}