using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    #region DATA
        #region BOOL
            public bool next;
        #endregion

        #region INT

        #endregion
    #endregion

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            if(next)
            {

            }
        }
    }
}
