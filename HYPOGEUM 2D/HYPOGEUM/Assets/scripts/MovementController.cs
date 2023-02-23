using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MovementController : MonoBehaviour
{
    //Stores input from the PlayerInput
    private Vector2 movementInput;

    private Vector3 direction;

    bool hasMoved;
    void Update()
    {
        if (movementInput.x == 0)
        {
            hasMoved = false;
        }
        else if (movementInput.x != 0 && !hasMoved)
        {
            hasMoved = true;

            GetMovementDirection();
        }

    }

    public void GetMovementDirection()
    {
        if (movementInput.x < 0)
        {
            if (movementInput.y > 0)
            {
                direction = new Vector3(-1.25f, 0, 0.75f);
            }
            else if (movementInput.y < 0)
            {
                direction = new Vector3(-1.25f, 0, -0.75f);
            }
            else
            {
                direction = new Vector3(-2.5f, 0, 0);
            }
            transform.position += direction;
        }
        else if (movementInput.x > 0)
        {
            if (movementInput.y > 0)
            {
                direction = new Vector3(1.25f,0, 0.75f);
            }
            else if (movementInput.y > 0)
            {
                direction = new Vector3(1.25f,0, -0.75f);
            }
            else
            {
                direction = new Vector3(2.5f, 0, 0);
            }

            transform.position += direction;
        }
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= direction;
    }


}
