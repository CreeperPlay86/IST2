using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPVP : MonoBehaviour
{
    #region DATA
        #region GAME OBJECS
            public Transform[] targetLocationPVP;
        #endregion
    #endregion  

    void OnEnable()
    {
        transform.LookAt(targetLocationPVP[0]);
    }
}
