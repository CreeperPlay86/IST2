using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activePvp : MonoBehaviour
{
    #region DATA
        #region UI
            public GameObject buttonAcceptPVP;
        #endregion

        #region FLOAT
            public float timer;
        #endregion

        #region CONNECT
            public gameManager GM;
        #endregion

        #region BOOL
            bool playerOnMe;
        #endregion

        #region INT 
            public int index;
        #endregion
    #endregion

    void Start()
    {
        GM = GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    void Update()
    {
        if(playerOnMe)
        {
            if(Input.GetKey(KeyCode.E))
            {
                timer += Time.deltaTime;

                if(timer >= 1f)
                {
                    timer = 0;

                    GM.activePVP(index); 
                }
            }

            buttonAcceptPVP.GetComponent<Image>().fillAmount = (timer / 1);
        }
        else
            timer = 0;
    }

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            playerOnMe = true;

            buttonAcceptPVP.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            playerOnMe = false;

            buttonAcceptPVP.GetComponent<Image>().fillAmount = 0;

            buttonAcceptPVP.SetActive(false);
        }
    }
}