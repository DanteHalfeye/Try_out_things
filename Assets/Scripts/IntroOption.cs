using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum IntroOptionType
{
    Play,
    Info,
    Exit,

    about,
    return1,
    return2,
    Start,
}
public class IntroOption : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public IntroOptionType type;
    [Space(10)]
    public Color colorNormal = Color.black;
    public Color colorHighlited = Color.yellow;

    [Space(30)]
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    [Space(10)]
    public GameObject title;
    [Space(5)]
    public GameObject info1;
    public GameObject info2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Text>().color = colorNormal;
        gameObject.GetComponentInChildren<Image>().color = colorNormal;

        switch (type)
        {
            case IntroOptionType.Play:
                title.SetActive(false);
                screen1.SetActive(false);
                screen3.SetActive(true);
                break;
            case IntroOptionType.Info:
                screen1.SetActive(false);
                screen2.SetActive(true);
                info1.SetActive(true);
                info2.SetActive(false);
                break;
            case IntroOptionType.Exit:
                Application.Quit();
                break;

            case IntroOptionType.about:
                info1.SetActive(false);
                info2.SetActive(true);
                break;
            case IntroOptionType.return1:
                screen1.SetActive(true);
                screen2.SetActive(false);
                break;
            case IntroOptionType.return2:
                info1.SetActive(true);
                info2.SetActive(false);
                break;
            case IntroOptionType.Start:
                SceneManager.LoadScene("Tutorial");
                break;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Text>().color = colorHighlited;
        gameObject.GetComponentInChildren<Image>().color = colorHighlited;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        gameObject.GetComponent<Text>().color = colorNormal;
        gameObject.GetComponentInChildren<Image>().color = colorNormal;
    }
}
