using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDebug : MonoBehaviour
{

    [SerializeField] GameObject box;
    [SerializeField] float pushforce;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = box.transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
            {
            rb.AddForce(new Vector2(pushforce, 0));
        }
    }
}
