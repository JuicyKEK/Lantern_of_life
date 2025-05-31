using JuicyDI;
using JuicyDI.Attributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Player.External.Controllers
{
    [SequenceParticipant(100)]
    public class InputController : MonoBehaviour , ISequence
    {
        public InputActionAsset inputActions;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _jumpAction;
        
        public void MethodInit()
        {
            // _moveAction = inputActions.FindAction("Move");
            // _lookAction = inputActions.FindAction("Look");
            // _jumpAction = inputActions.FindAction("Jump");
            //
            // _moveAction.performed += OnMove;
            // _lookAction.performed += OnLook;
            // _jumpAction.performed += OnJump;
            //
            // _moveAction.Enable();
            // _lookAction.Enable();
            // _jumpAction.Enable();
        }

        public void MethodStart()
        {
            
        }
        
        private void OnDisable()
        {
            // _moveAction.performed -= OnMove;
            // _lookAction.performed -= OnLook;
            // _jumpAction.performed -= OnJump;
        }

    }
}