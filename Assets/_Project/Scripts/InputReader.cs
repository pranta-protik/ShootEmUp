using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootEmUp
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputAction _moveAction;

        public Vector2 Move => _moveAction.ReadValue<Vector2>();

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _moveAction = _playerInput.actions["Move"];
        }
    }
}