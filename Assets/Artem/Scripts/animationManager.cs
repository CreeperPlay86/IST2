using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationManager : MonoBehaviour
{
    #region DATA
        #region GAME OBJECTS
            public GameObject[] modelPlayer;

            public Animator anim;
        #endregion

        #region STRING
            public string moodPlayer;
        #endregion

        #region BOOL
            public bool isFarmStrength;

            public bool isJump;
        #endregion

        #region INT
            public int indexAnimation; 
        #endregion
    #endregion

    void Update()
    {
        if(isFarmStrength)
        {
            Debug.Log("0");
            anim.SetInteger("indexAnimation", 0);

            return;
        }

        if(moodPlayer == "idle")
        {
            Debug.Log("1");
            anim.SetInteger("indexAnimation", 1);

            return;
        }

        if(isJump)
        {
            Debug.Log("2");
            anim.SetInteger("indexAnimation", 2);

            return;
        }

        if(moodPlayer == "run")
        {
            Debug.Log("3");
            anim.SetInteger("indexAnimation", 3);
        }
    }
}
