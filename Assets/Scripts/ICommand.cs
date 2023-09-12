using UnityEngine;

namespace NinetySix
{
    public interface ICommand
    {
        void Execute(GameObject player);
    }
}