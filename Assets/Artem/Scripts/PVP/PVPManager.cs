using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PVPManager : MonoBehaviour
{
    #region DATA
        #region UI
            public GameObject winPlayer;

            public GameObject panelComponentPVP;
        #endregion

        #region FLOAT
            public float currenthealthPlayer; // level player * 50

            public float levelEnemy;
            public float levelPlayer;
        #endregion

        #region CONNECT
            public gameManager GM;
        #endregion
    #endregion

    void Start()
    {
        GM = GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    #region VOID and IE
        public void startPVP(float _levelEnemy, float _levelPlayer)
        {
            levelEnemy = _levelEnemy;
            levelPlayer = _levelPlayer;

            currenthealthPlayer = 50f;
            Debug.Log(currenthealthPlayer);

            panelComponentPVP.SetActive(true);
            winPlayer.GetComponent<Image>().fillAmount = ((currenthealthPlayer / (1 * 100)));

            StartCoroutine(damagePlayerTimer());
        }
        void updateFieldAmount()
        {
            winPlayer.GetComponent<Image>().fillAmount = ((currenthealthPlayer / (1 * 100)));
        }

        public void clickPlayer()
        {
            currenthealthPlayer += ((levelPlayer / 3.25f) * 4f);

            if(currenthealthPlayer >= 100)
                win();

            updateFieldAmount();
        }

        #region WIN or LOOSE
            public void win()
            {
                Debug.Log("win");
                winPlayer.GetComponent<Image>().fillAmount = 0.5f;
                panelComponentPVP.SetActive(false);

                GM.winPVP((levelEnemy + 1));
            }
            public void loose()
            {
                winPlayer.GetComponent<Image>().fillAmount = 0.5f;
                panelComponentPVP.SetActive(false);

                GM.loosePVP();
            }
        #endregion

        IEnumerator damagePlayerTimer()
        {
            yield return new WaitForSeconds(.125f);

            damagePlayer();
        }
        void damagePlayer()
        {
            currenthealthPlayer -= (1.4f * (levelEnemy + 1));

            updateFieldAmount();
            
            if(currenthealthPlayer > 0)
            {
                if(currenthealthPlayer >= 100)
                {
                    win();
                    
                    return;
                }

                StartCoroutine(damagePlayerTimer());
            }
            else
                loose();
        }
    #endregion
}
