using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class SlotParameter : MonoBehaviour
{

    public bool isEmpty = false;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (!isEmpty)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
    }
}
