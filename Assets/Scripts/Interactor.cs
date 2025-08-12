using UnityEngine;
using UnityEngine.InputSystem; // New Input System

interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractorRange = 3f;

    // InputAction reference for interaction
    public InputAction interactAction;
 private void OnEnable()
    {
        interactAction.Enable();
    }

    private void OnDisable()
    {
        interactAction.Disable();
    }
    void Update()
    {
        // Check if the interaction button was pressed this frame
        if (interactAction.WasPerformedThisFrame())
        {
            Debug.Log("E Pressed - Input works");

            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            Debug.DrawRay(InteractorSource.position, InteractorSource.forward * InteractorRange, Color.red, 1f);

            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractorRange))
            {
                Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);

                if (hitInfo.collider.TryGetComponent<IInteractable>(out var interactObj))
                {
                    interactObj.Interact();
                    Debug.Log("Pressed E");
                }
                else
                {
                    Debug.Log("Hit object but no IInteractable component found.");
                }
            }
            else
            {
                Debug.Log("Raycast hit nothing.");
            }
        }
    }
}