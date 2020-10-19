using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator_NoAngles : MonoBehaviour
{
    public Transform ATransform;
    public Transform BTransform;
    public Transform CTransform;
    public float RotationSpeed = 55;
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

    private void Update()
    {
        var state = new RotatorState_NoAngles(ATransform, BTransform, CTransform);

        var targetPosition = state.B_prime;

        var targetAngle = Mathf.Atan2(targetPosition.z, targetPosition.x) * Mathf.Rad2Deg;
        var deltaEuler = Mathf.DeltaAngle(ATransform.localRotation.eulerAngles.y, -targetAngle);
        var frameRotation = Mathf.Clamp(deltaEuler, -RotationSpeed * Time.deltaTime, RotationSpeed * Time.deltaTime);
        ATransform.Rotate(ATransform.up, frameRotation, Space.Self);
    }

    private void OnDrawGizmos()
    {
        if (DrawGizmos
            && ATransform && BTransform && CTransform)
        {
            var state = new RotatorState_NoAngles(ATransform, BTransform, CTransform);

            var bPosition = state.GetBPosition(out var bPrime);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(ATransform.position, bPrime);

            //Gizmos.color = Color.blue;
            //Gizmos.DrawLine(state.A, state.P3C);
        }
    }
}
