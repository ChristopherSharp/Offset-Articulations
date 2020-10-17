using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Solves case where +/- B.x && B.forward is parallel to A.forward
    /// </summary>
    public class Rotator_Cannon90_Z0 : MonoBehaviour
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

        private void Start()
        {
            var state = new RotatorState_Cannon90_Z0(ATransform, BTransform, CTransform);
            ATransform.Rotate(ATransform.up, state.Theta);
        }

        private void OnDrawGizmos()
        {
            if(DrawGizmos 
                && ATransform && BTransform && CTransform)
            {
                var state = new RotatorState_Cannon90_Z0(ATransform, BTransform, CTransform);

                Gizmos.color = Color.black;
                Gizmos.DrawLine(state.A, state.C);
                Gizmos.DrawLine(state.A, state.B);

                Gizmos.color = Color.green;
                Gizmos.DrawLine(state.A, state.C2);
                Gizmos.DrawLine(state.B, state.C2);
                Gizmos.DrawLine(state.C2, state.C);
                Gizmos.DrawLine(state.A, state.M);
            }
        }
    }
}