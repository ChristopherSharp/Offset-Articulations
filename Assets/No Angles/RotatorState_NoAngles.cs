﻿using UnityEngine;

public class RotatorState_NoAngles
{
    private readonly Transform _aTransform;
    private readonly Transform _bTransform;
    private readonly Transform _cTransform;
    public RotatorState_NoAngles(Transform aTransform, Transform bTransform, Transform cTransform)
    {
        _aTransform = aTransform;
        _bTransform = bTransform;
        _cTransform = cTransform;
    }

    public bool GetBPosition(out Vector3 b_prime)
    {
        var A = _aTransform.position;
        var C = _cTransform.position;
        var s = (_bTransform.position - _aTransform.position).magnitude;
        var x0 = 0;
        var z0 = 0;
        var r0 = s;
        var u = C.x;
        var v = C.z;
        var x1 = u / 2;
        var z1 = v / 2;
        var r1 = Mathf.Sqrt(Mathf.Pow(u, 2) + Mathf.Pow(v, 2)) / 2;
        var d = r1;
        var a = (Mathf.Pow(r0, 2) - Mathf.Pow(r1, 2) + Mathf.Pow(d, 2)) / (2 * d);
        var h = Mathf.Sqrt(Mathf.Pow(r0, 2) - Mathf.Pow(a, 2));
        var x2 = x0 + a * (x1 - x0) / d;
        var z2 = z0 + a * (z1 - z0) / d;
        var x3 = x2 + h * (z1 - z0) / d;
        var z3 = z2 - h * (x1 - x0) / d;
        var P3 = new Vector3(x3, 0, z3);
        var x3_prime = x2 - h * (z1 - z0) / d;
        var y3_prime = z2 + h * (x1 - x0) / d;
        var P3_prime = new Vector3(x3_prime, 0, y3_prime);
        var AP3 = P3 - A;
        var P3C = C - P3;
        var resultingCross = Vector3.Cross(AP3, P3C);
        Debug.Log(resultingCross);
        b_prime = Vector3.Cross(AP3, P3C).y < 0 ? P3 : P3_prime;
        return true;
    }

    public Vector3 A => _aTransform.position;
    public Vector3 B => _bTransform.position;
    public Vector3 C => _cTransform.position;

    public float s => (_bTransform.position - _aTransform.position).magnitude;

    //Circle 1 is A, centered at 0 about itself. 
    public float x0 => 0;
    public float y0 => 0;
    public float r0 => s;

    public float u => C.x;
    public float v => C.z;

    public float x1 => u / 2;
    public float y1 => v / 2;
    public float r1 => Mathf.Sqrt(Mathf.Pow(u, 2) + Mathf.Pow(v, 2)) / 2;

    public float d => r1;
    public float a => (Mathf.Pow(r0, 2) - Mathf.Pow(r1, 2) + Mathf.Pow(d, 2)) / (2 * d);
    public float h => Mathf.Sqrt(Mathf.Pow(r0, 2) - Mathf.Pow(a, 2));

    public float x2 => x0 + a * (x1 - x0) / d;
    public float y2 => y0 + a * (y1 - y0) / d;

    //First solution P3
    public float x3 => x2 + h * (y1 - y0) / d;
    public float y3 => y2 - h * (x1 - x0) / d;

    public Vector3 P3 => new Vector3(x3, 0, y3);

    //Second solution P3'
    public float x3_prime => x2 - h * (y1 - y0) / d;
    public float y3_prime => y2 + h * (x1 - x0) / d;

    public Vector3 P3_prime => new Vector3(x3_prime, 0, y3_prime);

    public Vector3 AP3 => P3 - A;
    public Vector3 P3C => C - P3;

    public Vector3 B_prime => Vector3.Cross(AP3, P3C).y < 0 ? P3 : P3_prime;
}
