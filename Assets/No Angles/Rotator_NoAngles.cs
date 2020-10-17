using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator_NoAngles : MonoBehaviour
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
        var state = new RotatorState_NoAngles(ATransform, BTransform, CTransform);
    }

    private void OnDrawGizmos()
    {
        if (DrawGizmos
            && ATransform && BTransform && CTransform)
        {
            var state = new RotatorState_NoAngles(ATransform, BTransform, CTransform);

            var s1 = state.P3;
            var s2 = state.P3_prime;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(state.A, state.B_prime);

            //Gizmos.color = Color.blue;
            //Gizmos.DrawLine(state.A, state.P3C);
        }
    }
}
