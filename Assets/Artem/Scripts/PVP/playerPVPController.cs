using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPVPController : MonoBehaviour
{
    #region DATA
        #region FLOAT
            public float currentHealth;
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
        public void damageMe(int level)
        {
            currentHealth -= (10 * (level + 1));

            if(currentHealth <= 0)
            {
                GM.loosePVP();
            }
        }
    #endregion
}
