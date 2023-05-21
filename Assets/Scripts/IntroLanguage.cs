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
    public Text textInfo;
    public Text textExit;

    public Text textinfo2;
    public Text textReturn;

    public Text textMission;
    public Text textMission2;
    public Text textStart;

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
        TextAsset textAsset = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Files/Language.txt", typeof(TextAsset));
        List<string> wordList = textAsset.text.Split(";").ToList();
        List<string> wordEnglish = new();
        List<string> wordSpanish = new();

        foreach(string s in wordList)
        {
            string[] tmp = new string[2];
            tmp = s.Split(",");
            if(tmp.Length > 1)
            {
                wordEnglish.Add(tmp[0]);
                wordSpanish.Add(tmp[1]);
            }
        }
        switch (Memory.language)
        {
            case LanguageType.English:
                textPlay.text = wordEnglish[0];
                textInfo.text = wordEnglish[1];
                textExit.text = wordEnglish[2];
                textinfo2.text = wordEnglish[3];
                textReturn.text = wordEnglish[4];
                textMission.text = wordEnglish[5];
                textMission2.text = wordEnglish[6];
                textStart.text = wordEnglish[7];
                break;
            case LanguageType.Spanish:
                textPlay.text = wordSpanish[0]; 
                textInfo.text = wordSpanish[1];
                textExit.text = wordSpanish[2];
                textinfo2.text = wordSpanish[3];
                textReturn.text = wordSpanish[4];
                textMission.text = wordSpanish[5];
                textMission2.text = wordSpanish[6];
                textStart.text = wordSpanish[7];
                break;
        }
    }
}
