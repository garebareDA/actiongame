﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameMnager;
    public void OnButtonClick()
    {
        gameMnager = GameObject.Find("Game Manager");
        gameMnager.SendMessage("title");
    }
}
