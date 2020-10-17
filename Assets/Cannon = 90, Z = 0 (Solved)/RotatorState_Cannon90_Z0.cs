using UnityEngine;

namespace Assets.Scripts
{
    public class RotatorState_Cannon90_Z0
    {
        private readonly Transform _aTransform;
        private readonly Transform _bTransform;
        private readonly Transform _cTransform;
        public RotatorState_Cannon90_Z0(Transform aTransform, Transform bTransform, Transform cTransform)
        {
            _aTransform = aTransform;
            _bTransform = bTransform;
            _cTransform = cTransform;
        }

        public Vector3 A => _aTransform.position;
        public Vector3 B => _bTransform.position;
        public Vector3 C => _cTransform.position;

        public float d => (B - A).magnitude;
        public float h => (C - A).magnitude;
        public float s => Mathf.Sqrt(Mathf.Pow(h, 2) - Mathf.Pow(d, 2));
        public Vector3 C2 => _aTransform.TransformPoint(new Vector3(d, 0, s));
        public Vector3 M => C2 + (C - C2) / 2;
        public float Theta => -2 * Mathf.Asin((C2 - M).magnitude / h) * Mathf.Rad2Deg;
    }
}