using UnityEngine;

public class NumberGenerator: MonoBehaviour, IInteractable
{ public void Interact()
    {
    Debug.Log("Number Generated: " + Random.Range(0, 100));
}
    
}
