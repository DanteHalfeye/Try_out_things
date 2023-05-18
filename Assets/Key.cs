using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Key : MonoBehaviour
{
    GameObject[] gameObjects;

    private void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("door");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject go in gameObjects)
            {
                go.SetActive(false);
            }
        }
    }
}
