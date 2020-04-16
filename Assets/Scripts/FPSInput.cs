using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{


    private CharacterController _characterController;
    public float Speed = 6.0f;
    public float Gravity = -9.8f;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var deltax = Input.GetAxis("Horizontal") * Speed;
        var deltaz = Input.GetAxis("Vertical") * Speed;
        
        var movement = new Vector3(deltax,0,deltaz);
        movement = Vector3.ClampMagnitude(movement, Speed);

        movement.y = Gravity;

        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
