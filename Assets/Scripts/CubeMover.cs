using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float _speedMagnification;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _moveSpeed;

    private Vector3 _endScale;
    private Vector3 _currentScale;
    private float _magnificationFactor;


    private void Start()
    {
        
        _magnificationFactor = 100f;
        _currentScale = transform.localScale;
        _endScale = new Vector3(transform.localScale.x + _magnificationFactor, transform.localScale.y + _magnificationFactor, transform.localScale.z + _magnificationFactor);
        
    }

    private void Update()
    {
        _currentScale = Vector3.MoveTowards(_currentScale, _endScale, _speedMagnification * Time.deltaTime);
        transform.localScale = _currentScale;
        transform.Rotate(0, _speedRotation * Time.deltaTime, 0);
        transform.Translate(transform.forward * _moveSpeed * Time.deltaTime, Space.World);
    }
}
