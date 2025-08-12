using System.IO.Compression;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private Vector2 _moveD;

    public InputActionReference moveAction;
    private void OnEnable()
    {
        moveAction.action.Enable(); // Must enable the action
    }

    private void Update()
    {
        _moveD = moveAction.action.ReadValue<Vector2>();
    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
     rb.linearVelocity = new Vector3(_moveD.x * speed, rb.linearVelocity.y, _moveD.y * speed);
    }
}
