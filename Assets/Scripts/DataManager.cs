using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataManager 
{
    private static DataManager instance = new DataManager();
    public static DataManager Instance => instance;

    private InputInfo playerInputInfo;
    public InputInfo PlayerInputInfo { get { return playerInputInfo; } }

    private string jsonStr;

    private DataManager() {
        playerInputInfo = new InputInfo();
        jsonStr = Resources.Load<TextAsset>("InputActions").text;
    }

    public InputActionAsset GetCurrentActionAsset()
    {
        string str = jsonStr.Replace("<up>", playerInputInfo.up);
        str = str.Replace("<down>", playerInputInfo.down);
        str = str.Replace("<left>", playerInputInfo.left);
        str = str.Replace("<right>", playerInputInfo.right);
        str = str.Replace("<jump>", playerInputInfo.jump);
        str = str.Replace("<fire>", playerInputInfo.fire);

        return InputActionAsset.FromJson(str);

    }

}
