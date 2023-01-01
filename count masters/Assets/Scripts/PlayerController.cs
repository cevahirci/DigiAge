using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterSpawner characterSpawner;
    [SerializeField] private UIController uıController;
    [SerializeField] private float movementRange;
    [SerializeField] private float moveSpeed;
    private Touch touch;

    private void Update()
    {
        Move();
        Control();
        StayInRange();
    }

    private void Move()
    {
        if (!uıController.isStarted)
        {
            return;
        }

        if (uıController.isFinish)
        {
            return;
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void Finish()
    {
        if (transform.position.z == 107)
        {
            uıController.Finish();
        }
    }
    private void Control()
    {
        if (!uıController.isStarted)
        {
            return;
        }

        if (uıController.isFinish)
        {
            return;
        }
        //----------with keyboard----------------
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed *Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed *Time.deltaTime);
        }
        //---------------------------------------
        //----------with touchscreen-------------
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.Translate(Vector3.right * touch.deltaPosition.x * Time.deltaTime);
            }
        }
        //----------------------------------------
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
    }
}
