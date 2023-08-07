using UnityEngine;

namespace ShootEmUp
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Transform[] _backgrounds;
        [SerializeField] private float _smoothing = 10f;
        [SerializeField] private float _multiplier = 15f;

        private Transform _cam;
        private Vector3 _previousCamPos;

        private void Awake() => _cam = Camera.main.transform;
        private void Start() => _previousCamPos = _cam.position;

        private void Update()
        {
            for (var i = 0; i < _backgrounds.Length; i++)
            {
                var parallax = (_previousCamPos.y - _cam.position.y) * (i * _multiplier);
                var targetY = _backgrounds[i].position.y + parallax;

                var targetPosition = new Vector3(_backgrounds[i].position.x, targetY, _backgrounds[i].position.z);

                _backgrounds[i].position = Vector3.Lerp(_backgrounds[i].position, targetPosition, _smoothing * Time.deltaTime);
            }

            _previousCamPos = _cam.position;
        }
    }
}