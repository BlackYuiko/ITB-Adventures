using Assets.Scripts.Interactions;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private IInteractable currentInteractable;

    [SerializeField]
    private InteractionUI interactionUI;

    void Update()
    {
        if (currentInteractable != null && currentInteractable.CanInteract())
        {
            interactionUI.Show(
                currentInteractable.GetInteractionPrompt());

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentInteractable.Interact();
            }
        }
        else
        {
            interactionUI.Hide();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //Detecta cuando el jugador entra en contacto con un objeto
                                                        //que tiene un collider marcado como "Is Trigger".
                                                        // Si el objeto tiene un componente que implementa la interfaz
                                                        // IInteractable, lo asigna a currentInteractable.
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // Detecta cuando el jugador sale del contacto con un objeto
                                                       // que tiene un collider marcado como "Is Trigger".
                                                       // Si el objeto tiene un componente que implementa la interfaz
                                                       // IInteractable, lo desasigna de currentInteractable.
                                                       // Sin esto, el jugador podría seguir interactuando con un objeto
                                                       // incluso después de haberse alejado de él.
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }
}
