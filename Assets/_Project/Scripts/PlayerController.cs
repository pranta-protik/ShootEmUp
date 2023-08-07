using UnityEngine;

namespace ShootEmUp
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _smoothness = 0.1f;
        [SerializeField] private float _leanAngle = 15f;
        [SerializeField] private float _leanSpeed = 5f;
        [SerializeField] private GameObject _model;

        [Header("Camera Bounds")] 
        [SerializeField] private Transform _cameraFollow;
        [SerializeField] private float _minX = -3f;
        [SerializeField] private float _maxX = 3f;
        [SerializeField] private float _minY = -1f;
        [SerializeField] private float _maxY = 1.4f;

        private InputReader _input;
        private Vector3 _currentVelocity;
        private Vector3 _targetPosition;

        private void Start()
        {
            _input = GetComponent<InputReader>();
        }

        private void Update()
        {
            _targetPosition += new Vector3(_input.Move.x, _input.Move.y, 0f) * (_speed * Time.deltaTime);

            var minPlayerX = _cameraFollow.position.x + _minX;
            var maxPlayerX = _cameraFollow.position.x + _maxX;
            var minPlayerY = _cameraFollow.position.y + _minY;
            var maxPlayerY = _cameraFollow.position.y + _maxY;

            _targetPosition.x = Mathf.Clamp(_targetPosition.x, minPlayerX, maxPlayerX);
            _targetPosition.y = Mathf.Clamp(_targetPosition.y, minPlayerY, maxPlayerY);

            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, _smoothness);

            var targetRotationAngle = -_input.Move.x * _leanAngle;

            var currentYRotation = transform.localEulerAngles.y;
            var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, _leanSpeed * Time.deltaTime);

            transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);
        }
    }
}
