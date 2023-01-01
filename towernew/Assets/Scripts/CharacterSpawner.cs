using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public Transform player;
    public int characterNumber; // değişti
    [SerializeField] private GameObject character;
    [Range(0f,1f)][SerializeField] private float distanceFactor, radius;

    private void Start()
    {
        characterNumber = 1; // yeni
        player = transform;
    }

    public void Spawn(int times)
    {
        //burdan ----
        characterNumber += times;
        while (times > 0)
        {
            Instantiate(character, transform.position, Quaternion.Euler(-90,0,0),transform.parent);
            FormatCharacter();
            times--;
        }
        Debug.Log(characterNumber);
        // --- buraya bazı yerler değişti
    }

    private void FormatCharacter()
    {
        for (int i = 1; i <= player.parent.childCount - 3; i++)
        {
            var x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            var z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);

            var newPos = new Vector3(x, 0.54f, z);
            player.parent.GetChild(i+2).transform.position = newPos;
        }
    }
}
