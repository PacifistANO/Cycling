using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        ChangeScale(ref _currentScale.x, ref _endScale.x);
        ChangeScale(ref _currentScale.y, ref _endScale.y);
        ChangeScale(ref _currentScale.z, ref _endScale.z);
        transform.localScale = _currentScale;
        transform.Rotate(0, _speedRotation * Time.deltaTime, 0);
        transform.Translate(transform.forward * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void ChangeScale(ref float currentScale, ref float endScale)
    {
        currentScale = Mathf.MoveTowards(currentScale, endScale, _speedMagnification * Time.deltaTime);
    }
}
