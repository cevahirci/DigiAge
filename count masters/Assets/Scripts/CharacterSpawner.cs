using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [Range(0f,1f)][SerializeField] private float distanceFactor, radius;
    [SerializeField] private GameObject character;
    public int characterNumber;
    public Transform player;
    private int i = 1;

    private void Start()
    {
        characterNumber = 1;
        player = transform;
    }

    private void Update()
    {
        characterNumber = player.parent.childCount - 2;
    }

    public void Spawn(int times)
    {
        while (times > 0)
        {
            i++;
            Instantiate(character, CreateNewPosition(i), Quaternion.Euler(-90,0,0),transform.parent);
            times--;
            Debug.Log(player.parent.childCount - 2);
        }
    }

    private Vector3 CreateNewPosition(int i)
    {
        var x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
        var z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
        var newPosition = new Vector3(transform.position.x + x,transform.position.y,transform.position.z + z);
        return newPosition;
    }
}
