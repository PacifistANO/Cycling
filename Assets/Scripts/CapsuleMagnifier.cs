using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CapsuleMagnifier : MonoBehaviour
{
    [SerializeField] private float _speedMagnification;

    private Vector3 _startScale;
    private Vector3 _endScale;
    private Vector3 _currentScale;
    private float _magnificationFactor;


    private void Start()
    {
        _magnificationFactor = 5f;
        _startScale = transform.localScale;
        _currentScale = _startScale;
        _endScale = new Vector3(_startScale.x + _magnificationFactor, _startScale.y + _magnificationFactor, _startScale.z + _magnificationFactor);
    }

    private void Update()
    {
        if (_currentScale != _endScale)
        {
            ChangeScale(ref _currentScale.x, ref _endScale.x);
            ChangeScale(ref _currentScale.y, ref _endScale.y);
            ChangeScale(ref _currentScale.z, ref _endScale.z);
            transform.localScale = _currentScale;

            if (_currentScale == _endScale)
            {
                _endScale = _startScale;
                _startScale = _currentScale;
            }
        }
    }

    private void ChangeScale(ref float currentScale,ref float endScale)
    {
        currentScale = Mathf.MoveTowards(currentScale, endScale, _speedMagnification * Time.deltaTime);
    }
}
