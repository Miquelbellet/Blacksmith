using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematica1BackgroundScript : MonoBehaviour {
    public GameObject backgroundGreen, backgroundBrown;
    bool firsPartCinem;

    void Start () {
        backgroundGreen.SetActive(true);
        backgroundBrown.SetActive(true);
        firsPartCinem = true;
    }

    void Update () {
        ChangeBackground();
    }

    void ChangeBackground()
    {
        if (firsPartCinem)
        {
            backgroundGreen.SetActive(true);
            backgroundBrown.SetActive(false);
        }
        else
        {
            backgroundGreen.SetActive(false);
            backgroundBrown.SetActive(true);
        }
    }

    public void changeCinematic()
    {
        firsPartCinem = false;
    }
}
