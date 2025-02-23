using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class UIrevueText : MonoBehaviour
{
    #region DATA
        #region UI
            public GameObject[] spawnObjs;

            public Text textRevenueStrength;
        #endregion

        #region INT
            int numberSpawner;
        #endregion

        #region FLOAT
            public float positionY;
        #endregion

        #region CONNECT
            public gameManager GM;
        #endregion
    #endregion

    void OnEnable()
    {
        gameObject.transform.SetParent(GameObject.Find("canvasMain").transform);
        GM = GameObject.Find("gameManager").GetComponent<gameManager>();

        spawnObjs = GM.spawnObjsWitUIiRevenueStrength;

        numberSpawner = Random.Range(0,4);

        gameObject.GetComponent<RectTransform>().anchoredPosition = spawnObjs[numberSpawner].GetComponent<RectTransform>().anchoredPosition;

        choiceRevenueText();
    }

    void choiceRevenueText()
    {
        float textRevenue = PlayerPrefs.GetFloat("revenueStrengthPerClick");
        float testWithTypeReveueStrongth = 0;
        string typeRevenueTextStrength = "";
    
        if(textRevenue < 1000)
            testWithTypeReveueStrongth = textRevenue;
        if(textRevenue >= 1000)
        {
            testWithTypeReveueStrongth = textRevenue;
            testWithTypeReveueStrongth /= 1000;
            typeRevenueTextStrength = "K";
        }
        if(textRevenue >= 1000000 && textRevenue < 1000000000)
        {
            testWithTypeReveueStrongth = textRevenue;
            testWithTypeReveueStrongth /= 1000000;
            typeRevenueTextStrength = "M";
        }
        if(textRevenue >= 1000000000 && textRevenue < 1000000000000)
        {
            testWithTypeReveueStrongth = textRevenue;
            testWithTypeReveueStrongth /= 1000000000;
            typeRevenueTextStrength = "B";
        }
        if(textRevenue >= 1000000000000 && textRevenue < 1000000000000000)
        {
            testWithTypeReveueStrongth = textRevenue;
            testWithTypeReveueStrongth /= 1000000000000;
            typeRevenueTextStrength = "T";
        }
        if(textRevenue >= 1000000000000000 && textRevenue < 1000000000000000000)
        {
            testWithTypeReveueStrongth = textRevenue;
            testWithTypeReveueStrongth /= 1000000000000000;
            typeRevenueTextStrength = "Q";
        }

        float textRevenueStrengthWithMatg = (float)Math.Round(testWithTypeReveueStrongth,2);

        textRevenueStrength.text = "+" + textRevenueStrengthWithMatg.ToString() + typeRevenueTextStrength;
    }

    void Update()
    {
        #region MOVEMENT
            positionY += Time.deltaTime;

            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + positionY);
        #endregion
    }
}
