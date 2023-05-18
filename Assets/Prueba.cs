using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera.rect = new Rect { x = 0, y = 0, height = 0.5f, width = 0.5f };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
