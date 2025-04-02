using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    #region DATA
        #region CONNECT
            public playerPVPController PPC;
        #endregion

        #region GAMEOBJETS
            public GameObject playerPVP;
        #endregion
    #endregion

    void Start()
    {
        // StartCoroutine(goDamagePlayer());

        PPC = GameObject.Find("playerPVP(Clone)").GetComponent<playerPVPController>();
        playerPVP = GameObject.Find("playerPVP(Clone)");

        transform.LookAt(playerPVP.transform);
    }

    #region VOID and IE
        // IEnumerator goDamagePlayer()
        // {
            // yield return new WaitForSeconds(1f);
// 
            // PPC.damageMe(level);
// 
            // StartCoroutine(goDamagePlayer());
        // }
    #endregion
}
