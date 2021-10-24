using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class MoveController : MonoBehaviour
{
    CharacterController character;
    Vector3 moveVector;
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        character = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        character.Move(moveVector * speed * Time.fixedDeltaTime);
    }

    public void OnMovementChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
    }
}
