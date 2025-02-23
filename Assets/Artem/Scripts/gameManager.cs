using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class gameManager : MonoBehaviour
{
    #region DATA
        #region FLOAT
            public float currentQuantityStrength;

            public float revenueStrengthPerClick;
        #endregion

        #region INT
            public int currentQuantityCups;
        #endregion
        
        #region GAME OBJECTS
            public GameObject uiRevenueStrength;

            public GameObject cameraMain;

            #region PVP
                public Transform[] transformLocationPVPEnemy;
                public Transform[] transformLocationPVPPlayer;
                public Transform[] skinsPlayer;
                public GameObject[] enemyPVP;

                public GameObject cameraPVP;
            #endregion  
        #endregion

        #region UI
            public Text textCurrentQuantityStrength;

            public GameObject[] spawnObjsWitUIiRevenueStrength;
        #endregion
    #endregion

    

    #region VOID and IE
        public void loadGame()
        {
            currentQuantityStrength = PlayerPrefs.GetFloat("currentQuantityStrength");    

            updateAllText();
        }
        
        public void updateAllText()
        {
            float textStrentgth = 0f;
            string typeRevenueTextStrength = "";

            if(currentQuantityStrength < 1000)
                textStrentgth = currentQuantityStrength;

            if(currentQuantityStrength >= 1000)
            {
                textStrentgth = currentQuantityStrength;
                textStrentgth /= 1000;
                typeRevenueTextStrength = "K";
            }
            if(currentQuantityStrength >= 1000000 && currentQuantityStrength < 1000000000)
            {
                textStrentgth = currentQuantityStrength;
                textStrentgth /= 1000000;
                typeRevenueTextStrength = "M";
            }
            if(currentQuantityStrength >= 1000000000 && currentQuantityStrength < 1000000000000)
            {
                textStrentgth = currentQuantityStrength;
                textStrentgth /= 1000000000;
                typeRevenueTextStrength = "B";
            }
            if(currentQuantityStrength >= 1000000000000 && currentQuantityStrength < 1000000000000000)
            {
                textStrentgth = currentQuantityStrength;
                textStrentgth /= 1000000000000;
                typeRevenueTextStrength = "T";
            }
            if(currentQuantityStrength >= 1000000000000000 && currentQuantityStrength < 1000000000000000000)
            {
                textStrentgth = currentQuantityStrength;
                textStrentgth /= 1000000000000000;
                typeRevenueTextStrength = "Q";
            }
            
            float textStrentgthRounding = (float)Math.Round(textStrentgth, 2);

            textCurrentQuantityStrength.text = textStrentgthRounding.ToString() + typeRevenueTextStrength;
        }

        public void revenueStrength()
        {
            revenueStrengthPerClick = PlayerPrefs.GetFloat("revenueStrengthPerClick");
            currentQuantityStrength += revenueStrengthPerClick;

            Instantiate(uiRevenueStrength);

            PlayerPrefs.SetFloat("currentQuantityStrength", currentQuantityStrength);

            updateAllText();
        }

        public void activePVP(int index)
        {
            cameraPVP.GetComponent<cameraPVP>().index = index;

            cameraPVP.SetActive(true);

            cameraMain.SetActive(false);

            #region SPAWN PERS PVP
                Instantiate(enemyPVP[index]).transform.position = transformLocationPVPEnemy[index].position;
                Instantiate(skinsPlayer[0]).transform.position = transformLocationPVPPlayer[index].position;
            #endregion
        }

        #region PVP
            public void winPVP()
            {

            }

            public void loosePVP()
            {
                
            }
        #endregion
    #endregion



    void Start()
    {
        loadGame();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            updateAllText();
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            revenueStrength();
        }
    }
}