using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    //Tutorial
    bool swapScene = false;
    public float swapSceneCurrent = 0f;
    public float swapSceneMax = 3f;
    public float swapSceneFactor = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(swapScene)
        {
            if(swapSceneCurrent >= swapSceneMax)
            {
                SceneManager.LoadScene("Game");
            }
            else
            {
                swapSceneCurrent += swapSceneFactor;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            swapScene = true;
        }
    }
}
