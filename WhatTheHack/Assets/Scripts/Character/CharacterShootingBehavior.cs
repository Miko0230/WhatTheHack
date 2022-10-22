using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShootingBehavior : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 _mousePos;

    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private Transform _bulletTransform;
    [SerializeField]
    private bool _canFire;
    private float _timer;
    [SerializeField]
    private float _shootDelay;

    private void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        FirePointToMousePos();
        Shoots();
    }

    private void Shoots() //shooting on mouse click
    {
        if(!_canFire) //shooting Delay to stop the player from spamming
        {
            _timer += Time.deltaTime;
            if(_timer > _shootDelay)
            {
                _canFire = true;
                _timer = 0;
            }
        }

        if(Input.GetMouseButtonDown(0) && _canFire)
        {
            _canFire = false;
            Instantiate(_bullet,_bulletTransform.position,Quaternion.identity);
        }
    }

    private void FirePointToMousePos() //aims at mouse position
    {
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = _mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }
}
