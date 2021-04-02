using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3sslstrip : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject wrongCommand1;
    public GameObject wrongCommand2;

    public void OnClickInstall()
    {
        canvas1.SetActive (false);
        canvas2.SetActive (true);
    }

    public void OnClickCanvas2()
    {
        canvas2.SetActive (false);
        canvas3.SetActive (true);
    }

    public void OnClickCanvas3()
    {
        canvas3.SetActive (false);
        canvas4.SetActive (true);
    }

    // when wrong  choices are made   
    //wrong choice on canvas  2
    public void OnClickWrong1()
    {
        canvas2.SetActive (false);
        wrongCommand1.SetActive (true);
    }
    public void GoBackTo2()
    {
        wrongCommand1.SetActive (false);
        canvas2.SetActive (true);
    }
    //wrong choice on canvas  3
    public void OnClickWrong2()
    {
        canvas3.SetActive (false);
        wrongCommand2.SetActive (true);
    }
    public void GoBackTo3()
    {
        wrongCommand2.SetActive (false);
        canvas3.SetActive (true);
    }
}
