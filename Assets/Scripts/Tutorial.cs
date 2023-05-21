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

    //Language
    public List<Text> language;


    // Start is called before the first frame update
    void Start()
    {
        SetLanguage();
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerCurrent < timerMax) timerCurrent += timerFactor;
        else ChangeAlpha();

        FollowPlayer();
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
    void SetLanguage()
    {
        TextAsset textAsset = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Files/Language.txt", typeof(TextAsset));
        List<string> wordList = textAsset.text.Split(";").ToList();
        List<string> wordEnglish = new();
        List<string> wordSpanish = new();

        foreach (string s in wordList)
        {
            string[] tmp = new string[2];
            tmp = s.Split(",");
            if (tmp.Length > 1)
            {
                wordEnglish.Add(tmp[0]);
                wordSpanish.Add(tmp[1]);
            }
        }
        switch (Memory.language)
        {
            case LanguageType.English:
                language[0].text = wordEnglish[8];
                language[1].text = wordEnglish[9];
                language[2].text = wordEnglish[10];
                language[3].text = wordEnglish[11];
                language[4].text = wordEnglish[12];
                break;
            case LanguageType.Spanish:
                language[0].text = wordSpanish[8];
                language[1].text = wordSpanish[9];
                language[2].text = wordSpanish[10];
                language[3].text = wordSpanish[11];
                language[4].text = wordSpanish[12];
                break;
        }
    }
}
