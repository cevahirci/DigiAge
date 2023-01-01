using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float movementRange;
    [SerializeField] private CharacterSpawner characterSpawner;

    private void Update()
    {
        Move();
        Control();
        StayInRange();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void Control()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed *Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed *Time.deltaTime);
        }
    }

    private void StayInRange()
    {
        if (transform.position.x < -movementRange)
        {
            transform.position = new Vector3(-movementRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > movementRange)
        {
            transform.position = new Vector3(movementRange, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("+2"))
        {
            characterSpawner.Spawn(2);
        }
        if (other.gameObject.CompareTag("+7"))
        {
            characterSpawner.Spawn(7);
        }
        if (other.gameObject.CompareTag("+12"))
        {
            characterSpawner.Spawn(12);
        }
        //burdan ----
        if (other.gameObject.CompareTag("x3"))
        {
            characterSpawner.Spawn(characterSpawner.characterNumber * 2);
        }
        if (other.gameObject.CompareTag("x2"))
        {
            characterSpawner.Spawn(characterSpawner.characterNumber);
        }
        if (other.gameObject.CompareTag("x5"))
        {
            characterSpawner.Spawn(characterSpawner.characterNumber * 4);
        }
        // ----buraya eklendi
    }
}
