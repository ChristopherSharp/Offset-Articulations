﻿using UnityEngine;

namespace Assets.Scripts
{
    public class RotatorState_CannonAny_Z0
    {
        private readonly Transform _aTransform;
        private readonly Transform _bTransform;
        private readonly Transform _cTransform;
        public RotatorState_CannonAny_Z0(Transform aTransform, Transform bTransform, Transform cTransform)
        {
            _aTransform = aTransform;
            _bTransform = bTransform;
            _cTransform = cTransform;
        }


        public float Theta => -1;
    }
}