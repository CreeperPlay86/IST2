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

            public float currentQuantityCups;

            #region PVP
                public float levelPlayer;
            #endregion
        #endregion
        
        #region GAME OBJECTS
            public GameObject uiRevenueStrength;

            public GameObject cameraMain;

            #region PVP
                public Transform[] transformLocationPVPEnemy;
                public Transform[] transformLocationPVPPlayer;
                public GameObject[] skinsPlayer;
                public GameObject[] enemyPVP;

                public GameObject cameraPVP;

                public GameObject currentGameObjectPlayer;
                public GameObject currentGameObjectEnemy;
            #endregion  
        #endregion

        #region UI
            public Text textCurrentQuantityStrength;
            public Text textCurrentQuanityCups;

            public GameObject[] spawnObjsWitUIiRevenueStrength;
        #endregion

        #region CONNECT
            public PlayerController PC;

            public PVPManager PM;
        #endregion
    #endregion

    

    #region VOID and IE
        public void loadGame()
        {
            currentQuantityStrength = PlayerPrefs.GetFloat("currentQuantityStrength"); 
            currentQuantityCups = PlayerPrefs.GetFloat("currentQuantityCups");   

            updateAllText();
        }
        
        public void updateAllText()
        {
            #region STRENTGTH
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
            #endregion

            #region CUPS
                float textCups = 0f;
                string typeRevenueTextCup = "";

                if(currentQuantityCups < 1000)
                    textCups = currentQuantityCups;

                if(currentQuantityCups >= 1000)
                {
                    textCups = currentQuantityCups;
                    textCups /= 1000;
                    typeRevenueTextCup = "K";
                }
                if(currentQuantityCups >= 1000000 && currentQuantityCups < 1000000000)
                {
                    textCups = currentQuantityCups;
                    textCups /= 1000000;
                    typeRevenueTextCup = "M";
                }
                if(currentQuantityCups >= 1000000000 && currentQuantityCups < 1000000000000)
                {
                    textCups = currentQuantityCups;
                    textCups /= 1000000000;
                    typeRevenueTextCup = "B";
                }
                if(currentQuantityCups >= 1000000000000 && currentQuantityCups < 1000000000000000)
                {
                    textCups = currentQuantityCups;
                    textCups /= 1000000000000;
                    typeRevenueTextCup = "T";
                }
                if(currentQuantityCups >= 1000000000000000 && currentQuantityCups < 1000000000000000000)
                {
                    textCups = currentQuantityCups;
                    textCups /= 1000000000000000;
                    typeRevenueTextCup = "Q";
                }

                float textCupsRounding = (float)Math.Round(textCups, 2);

                textCurrentQuanityCups.text = textCupsRounding.ToString() + typeRevenueTextCup;
            #endregion
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
            PC.activePVP();

            cameraPVP.SetActive(true);
            cameraMain.SetActive(false);

            #region SPAWN PERS PVP
                currentGameObjectEnemy = Instantiate(enemyPVP[index]);
                currentGameObjectEnemy.transform.position = transformLocationPVPEnemy[0].position;

                currentGameObjectPlayer = Instantiate(skinsPlayer[0]);
                currentGameObjectPlayer.transform.position = transformLocationPVPPlayer[0].position;
            #endregion

            #region LVL PLAYER
                if (currentQuantityStrength <= 1000)
                    levelPlayer = 1;
                if(currentQuantityStrength > 1000 && currentQuantityStrength <= 7500)
                    levelPlayer = 2;
                if (currentQuantityStrength > 7500 && currentQuantityStrength <= 25000)
                    levelPlayer = 3;
                if(currentQuantityStrength > 25000 && currentQuantityStrength <= 110000)
                    levelPlayer = 4;
                if (currentQuantityStrength > 110000 && currentQuantityStrength <= 500000)
                    levelPlayer = 5;
                if (currentQuantityStrength > 500000 && currentQuantityStrength <= 2500000)
                    levelPlayer = 6;
                if (currentQuantityStrength > 2500000 && currentQuantityStrength <= 15000000)
                    levelPlayer = 7;
                if (currentQuantityStrength > 15000000 && currentQuantityStrength <= 210000000)
                    levelPlayer = 8;
                if(currentQuantityStrength > 210000000 && currentQuantityStrength <= 220000000000)
                    levelPlayer = 9;
            #endregion
            
            PM.startPVP((float)index, levelPlayer);
        }

        #region PVP
            public void winPVP(float levelEnemy)
            {
                currentQuantityCups += (int)(levelEnemy * 50 * (levelEnemy * 1.5f));
                PlayerPrefs.SetFloat("currentQuantityCups", currentQuantityCups);

                PC.disactivePVP();

                cameraPVP.SetActive(false);
                cameraMain.SetActive(true);

                Destroy(currentGameObjectEnemy.gameObject);
                Destroy(currentGameObjectPlayer.gameObject);

                updateAllText();
            }

            public void loosePVP()
            {
                PC.disactivePVP();

                cameraPVP.SetActive(false);
                cameraMain.SetActive(true);

                Destroy(currentGameObjectEnemy.gameObject);
                Destroy(currentGameObjectPlayer.gameObject);

                updateAllText();
            }
        #endregion
    #endregion



    void Start()
    {
        loadGame();

        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PM = GameObject.Find("PVPManager").GetComponent<PVPManager>();
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