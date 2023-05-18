using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]  GameObject recieverPortal;
    public float x;
    public float y;


        private void Start()
    {
        x = recieverPortal.transform.position.x;
        y = recieverPortal.transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            other.transform.position = new Vector3(x, y);

        }
    }

}
