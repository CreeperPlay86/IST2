using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPVP : MonoBehaviour
{
    #region DATA
        #region GAME OBJECS
            public Transform[] locationPVP;
            public Transform[] targetLocationPVP;
        #endregion

        #region INT
            public int index;
        #endregion
    #endregion  

    void OnEnable()
    {
        transform.position = locationPVP[index].position;
        transform.LookAt(targetLocationPVP[index]);
    }
}
