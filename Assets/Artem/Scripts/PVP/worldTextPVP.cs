using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldTextPVP : MonoBehaviour
{
    #region DATA
        #region TRANSFORM
            public Transform target;
        #endregion
    #endregion

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        transform.LookAt(target);
        // transform.rotation = Quaternion.Euler(transform.rotation.x - 180f, transform.rotation.y, transform.rotation.z);
    }
}
