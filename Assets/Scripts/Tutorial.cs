using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public class Tutorial : MonoBehaviour
{
    public float timerCurrent;
    public float timerMax;
    public float timerFactor;
    [Space(5)]
    public float colorFadeFactor;
    public Color color;
    [Space(15)]
    public List<GameObject> listCanvas;
    [Space(10)]
    public Transform player;
    public Transform followPlayer;
    //Tutorial Scene
    [Space(20)]
    public bool tutorialScene = true;
    public Transform cube; 
    public Transform followCube;


    // Start is called before the first frame update
    void Start()
    {
        SetLanguage();
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        if(tutorialScene) FollowSquare();
        else
        {
            if (listCanvas[0].GetComponent<Text>().color.a <= 0.011f) gameObject.SetActive(false);
            if (timerCurrent < timerMax) timerCurrent += timerFactor;
            else ChangeAlpha();
        }
    }

    void SetColor()
    {
        foreach (GameObject g in listCanvas)
        {
            if (g.GetComponent<Text>())
            {
                g.GetComponent<Text>().color = color;
            }
            else if (g.GetComponent<SpriteRenderer>())
            {
                g.GetComponent<SpriteRenderer>().color = color;
            }
            else if (g.GetComponent<Image>())
            {
                g.GetComponent<Image>().color = color;
            }
        }
    }
    void ChangeAlpha()
    {
        foreach(GameObject g in  listCanvas)
        {
            if(g.GetComponent<Text>())
            {
                Text t = g.GetComponent<Text>();
                t.color = new Color(t.color.r, t.color.g, t.color.b, (t.color.a - colorFadeFactor));
            }
            else if(g.GetComponent<SpriteRenderer>())
            {
                SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (sr.color.a - colorFadeFactor));
            }
            else if (g.GetComponent<Image>())
            {
                Image i = g.GetComponent<Image>();
                i.color = new Color(i.color.r, i.color.g, i.color.b, (i.color.a - colorFadeFactor));
            }
        }
    }
    void FollowPlayer()
    {
        followPlayer.position = player.position;
    }
    void FollowSquare()
    {
        followCube.position = cube.position;
    }
    void SetLanguage()
    {
        #if UNITY_EDITOR
        TextAsset textAsset = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Files/Language.txt", typeof(TextAsset));
        #else
        TextAsset textAsset = Resources.Load<TextAsset>("Text/Language");
        #endif
        List<string> wordList = textAsset.text.Split(";").ToList();
        List<string> wordEnglish = new();
        List<string> wordSpanish = new();

        foreach (string s in wordList)
        {
            string[] tmp = new string[2];
            tmp = s.Split("|");
            if (tmp.Length > 1)
            {
                wordEnglish.Add(tmp[0]);
                wordSpanish.Add(tmp[1]);
            }
        }
        List<string> tmpLanguage = new();
        switch (Memory.language)
        {
            case LanguageType.English:
                tmpLanguage = wordEnglish;
                break;
            case LanguageType.Spanish:
                tmpLanguage = wordSpanish;
                break;
        }
        listCanvas[0].GetComponent<Text>().text = tmpLanguage[13];
        listCanvas[1].GetComponent<Text>().text = tmpLanguage[14];
        listCanvas[2].GetComponent<Text>().text = tmpLanguage[15];
        listCanvas[3].GetComponent<Text>().text = tmpLanguage[16];
        listCanvas[4].GetComponent<Text>().text = tmpLanguage[17];
    }
}
