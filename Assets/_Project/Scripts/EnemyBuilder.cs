using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace ShootEmUp
{
    public class EnemyBuilder
    {
        private GameObject _enemyPrefab;
        private SplineContainer _spline;
        private GameObject _weaponPrefab;
        private float _speed;

        public EnemyBuilder SetBasePrefab(GameObject prefab)
        {
            _enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpline(SplineContainer spline)
        {
            _spline = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab(GameObject prefab)
        {
            _weaponPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpeed(float speed)
        {
            _speed = speed;
            return this;
        }

        public GameObject Build()
        {
            var instance = GameObject.Instantiate(_enemyPrefab);
            var splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = _spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineComponent.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineComponent.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = _speed;

            instance.transform.position = _spline.EvaluatePosition(0f);

            return instance;
        }
    }
}