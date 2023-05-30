using System;
using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using UnityEngine;
using UnityEngine.InputSystem;
using WeaponSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInput Input { get; private set; }
    
    public ExampleCharacterController Character;
    public ExampleCharacterCamera CharacterCamera;
    public WeaponHandler WeaponHandler;
    
    private void Awake()
    {
        Input = new PlayerInput();
        Input.Enable();

        WeaponHandler.Init();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Tell camera to follow transform
        CharacterCamera.SetFollowTransform(Character.CameraFollowPoint);

        // Ignore the character's collider(s) for camera obstruction checks
        CharacterCamera.IgnoredColliders.Clear();
        CharacterCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }*/

        HandleCharacterInput();
    }

    private void LateUpdate()
    {
        // Handle rotating the camera along with physics movers
        if (CharacterCamera.RotateWithPhysicsMover && Character.Motor.AttachedRigidbody != null)
        {
            CharacterCamera.PlanarDirection =
                Character.Motor.AttachedRigidbody.GetComponent<PhysicsMover>().RotationDeltaFromInterpolation *
                CharacterCamera.PlanarDirection;
            CharacterCamera.PlanarDirection = Vector3
                .ProjectOnPlane(CharacterCamera.PlanarDirection, Character.Motor.CharacterUp).normalized;
        }

        HandleCameraInput();
    }

    private void HandleCameraInput()
    {
        // Create the look input vector for the camera
        float mouseLookAxisUp = Input.General.Look.ReadValue<Vector2>().y;
        float mouseLookAxisRight = Input.General.Look.ReadValue<Vector2>().x;
        Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

        // Prevent moving the camera while the cursor isn't locked
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            lookInputVector = Vector3.zero;
        }
        
        // Apply inputs to the camera
        CharacterCamera.UpdateWithInput(Time.deltaTime, 0f, lookInputVector);

        // Handle toggling zoom level
        // if (Input.GetMouseButtonDown(1))
        // {
        //     CharacterCamera.TargetDistance =
        //         (CharacterCamera.TargetDistance == 0f) ? CharacterCamera.DefaultDistance : 0f;
        // }
    }

    private void HandleCharacterInput()
    {
        PlayerCharacterInputs characterInputs = new PlayerCharacterInputs
        {
            // Build the CharacterInputs struct
            MoveAxisForward = Input.General.Move.ReadValue<Vector2>().y,
            MoveAxisRight = Input.General.Move.ReadValue<Vector2>().x,
            CameraRotation = CharacterCamera.Transform.rotation
        };
        
        // Apply inputs to character
        Character.SetInputs(ref characterInputs);
    }
}
