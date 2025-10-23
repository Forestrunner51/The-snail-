using System.IO.Compression;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private Vector2 _moveD;

    public InputActionReference moveAction;
    public GameObject winText;
    public GameObject Res;
    public GameObject Qui;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winText.SetActive(false);
        Res.SetActive(false);
        Qui.SetActive(false);
    }
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
      Vector3 move = new Vector3(_moveD.x, 0, _moveD.y); // X for left/right, Y for forward/back
    Vector3 moveDir = transform.TransformDirection(move) * speed;
    rb.linearVelocity = new Vector3(moveDir.x, rb.linearVelocity.y, moveDir.z);
}
}
