using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerSuport : MonoBehaviour
{
    public void SelectButtonOnSwitch(Button buttonToSelect)
    {
        buttonToSelect.Select();
    }
}
