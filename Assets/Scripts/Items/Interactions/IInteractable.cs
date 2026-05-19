using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Interactions
{
	public interface IInteractable
	{
		void Interact();

		string GetInteractionPrompt();

        bool CanInteract();
    }
}