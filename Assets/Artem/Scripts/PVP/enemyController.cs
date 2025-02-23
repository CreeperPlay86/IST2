using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    #region DATA
        #region INT
            public int level;
        #endregion

        #region CONNECT
            public playerPVPController PPC;
        #endregion

        #region FLOAT
            public float currentHealth;
        #endregion
    #endregion

    void Start()
    {
        StartCoroutine(goDamagePlayer());

        PPC = GameObject.Find("playerPVP(Clone)").GetComponent<playerPVPController>();
    }

    #region VOID and IE
        IEnumerator goDamagePlayer()
        {
            yield return new WaitForSeconds(1f);

            PPC.damageMe(level);

            StartCoroutine(goDamagePlayer());
        }
    #endregion
}
