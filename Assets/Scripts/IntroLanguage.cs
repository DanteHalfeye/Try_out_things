using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public class IntroLanguage : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public LanguageType language;

    public Color colorNormal;
    public Color colorHighlited;

    //TextVariables
    public Text textPlay;
    public Text textInfo1;
    public Text textExit;
     [Space(7)] 
    public Text text1;
    public Text text2;
    public Text text3;
    public Text textAbout;
    public Text textReturn1;
     [Space(7)]
    public Text textInfo2;
    public Text textReturn2;
     [Space(7)]
    public Text textMissionTitle;
    public Text textMissionBody;
    public Text textStart;

    // Start is called before the first frame update
    void Start()
    {
        if(language == LanguageType.Spanish)
        {
            SetLanguage();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (language)
        {
            case LanguageType.Spanish:
                switch(Memory.language)
                {
                    case LanguageType.English:
                        Memory.language = LanguageType.Spanish;
                        break;
                }
                break;
            case LanguageType.English:
                switch(Memory.language)
                {
                    case LanguageType.Spanish:
                        Memory.language = LanguageType.English;
                        break;
                }
                break;
        }
        SetLanguage();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = colorHighlited;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        gameObject.GetComponent<Image>().color = colorNormal;
    }

    public void SetLanguage()
    {
        #if UNITY_EDITOR
        TextAsset textAsset = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Files/Language.txt", typeof(TextAsset));
        #else
        TextAsset textAsset = Resources.Load<TextAsset>("Text/Language");
        #endif
        List<string> wordList = textAsset.text.Split(";").ToList();
        List<string> wordEnglish = new();
        List<string> wordSpanish = new();

        foreach(string s in wordList)
        {
            string[] tmp = new string[2];
            tmp = s.Split("|");
            if(tmp.Length > 1)
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
        textPlay.text = tmpLanguage[0];
        textInfo1.text = tmpLanguage[1];
        textExit.text = tmpLanguage[2];

        text1.text = tmpLanguage[3];
        text2.text = tmpLanguage[4];
        text3.text = tmpLanguage[5];
        textAbout.text = tmpLanguage[6];
        textReturn1.text = tmpLanguage[7];

        textInfo2.text = tmpLanguage[8];
        textReturn2.text = tmpLanguage[9];

        textMissionTitle.text = tmpLanguage[10];
        textMissionBody.text = tmpLanguage[11];
        textStart.text = tmpLanguage[12];
    }
}
