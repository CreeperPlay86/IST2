using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPVPController : MonoBehaviour
{
    #region DATA
        #region GAME OBJECTS
            public GameObject enemyPVP;
        #endregion
    #endregion

    void Start()
    {
        StartCoroutine(lookAtEnemy());
    }

    IEnumerator lookAtEnemy()
    {
        yield return new WaitForSeconds(0.05f);
        
        enemyPVP = GameObject.FindGameObjectWithTag("enemyPVP");

        transform.LookAt(enemyPVP.transform);
    }
}
