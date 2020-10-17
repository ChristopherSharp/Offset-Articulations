using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Solves all cases where +/- B.x && B.forward may or may not be parallel to A.forward
    /// </summary>
    public class Rotator_CannonAny_Z0 : MonoBehaviour
    {
        public Transform ATransform;
        public Transform BTransform;
        public Transform CTransform;
        public bool DrawGizmos = true;

        private void Awake()
        {
            if (ATransform && BTransform && CTransform)
            {
                if (!BTransform.IsChildOf(ATransform))
                {
                    Debug.LogError($"B transform must be a child of A transform to rotate correctly");
                    enabled = false;
                }
            }
            else
            {
                Debug.Log($"Transform dependencies are missing");
                enabled = false;
            }
        }

        void Start()
        {
            var state = new RotatorState_CannonAny_Z0(ATransform, BTransform, CTransform);
            ATransform.Rotate(ATransform.up, state.Theta);
        }

        private void OnDrawGizmos()
        {
            if (DrawGizmos
               && ATransform && BTransform && CTransform)
            {
                var state = new RotatorState_CannonAny_Z0(ATransform, BTransform, CTransform);
            }
        }
    }
}