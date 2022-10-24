using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f;

    [SerializeField]
    private GameObject _player;
  private void Update()
  {
        PlayerMovement();
        PlayerShoot();
  }

    private void PlayerShoot() //Click to shoot and and aim at mouse position
    {
       
    }

    private void PlayerMovement() //WASD or ArrowKeys
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.position += new Vector3 (x ,z, 0) * _speed * Time.deltaTime;
    }
}
