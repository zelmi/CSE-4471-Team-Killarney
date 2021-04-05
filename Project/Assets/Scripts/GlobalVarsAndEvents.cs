using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalVarsAndEvents : MonoBehaviour
{
    public UnityEvent UnlockStorage;
    public UnityEvent UnlockManager;
    private static bool playerHasUsb = false;
    private static bool usbHasVirus = false;

    public static bool PlayerHasUsb{ get => playerHasUsb; set => playerHasUsb = value; }
    public static bool USBHasVirus{ get => usbHasVirus; set => usbHasVirus = value; }

}
