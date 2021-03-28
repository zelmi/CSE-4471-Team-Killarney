using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{   
    private bool usb {get; set;}
    private bool packetSniffer {get; set;}
    private bool sslStrip {get; set;}
    private bool employeeFiles {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        usb = false;
        packetSniffer = false;
        sslStrip = false;
        employeeFiles = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

}