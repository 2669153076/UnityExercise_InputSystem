using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public enum E_BtnType
{
    UP, DOWN, LEFT, RIGHT, JUMP, FIRE
}

public class ChangeInputPanel : MonoBehaviour
{
    public Text upText;
    public Text downText;
    public Text leftText;
    public Text rightText;
    public Text jumpText;
    public Text fireText;

    public Button upBtn;
    public Button downBtn;
    public Button leftBtn;
    public Button rightBtn;
    public Button jumpBtn;
    public Button fireBtn;

    private InputInfo inputInfo;
    private E_BtnType btnType;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        inputInfo = DataManager.Instance.PlayerInputInfo ;

        upBtn.onClick.AddListener(() =>
        {
            ChangeBtn(E_BtnType.UP);
        });
        downBtn.onClick.AddListener(() =>
        {
            ChangeBtn(E_BtnType.DOWN);
        });
        leftBtn.onClick.AddListener(() =>
        {
            ChangeBtn(E_BtnType.LEFT);
        });
        rightBtn.onClick.AddListener(() =>
        {
            ChangeBtn(E_BtnType.RIGHT);
        });
        jumpBtn.onClick.AddListener(() =>
        {
            ChangeBtn(E_BtnType.JUMP);
        });
        fireBtn.onClick.AddListener(() =>
        {
            ChangeBtn(E_BtnType.FIRE);
        });

        UpdateButtonInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 更新UI
    /// </summary>
    private void UpdateButtonInfo()
    {
        upText.text = inputInfo.up;
        downText.text = inputInfo.down;
        leftText.text = inputInfo.left;
        rightText.text = inputInfo.right;
        jumpText.text = inputInfo.jump;
        fireText.text = inputInfo.fire;
    }

    private void ChangeBtn(E_BtnType type)
    {
        btnType = type;
        InputSystem.onAnyButtonPress.CallOnce(ChangeBtnReally);
    }
    private void ChangeBtnReally(InputControl control)
    {
        print(control.path);
        string[] strs = control.path.Split('/');
        string path = "<" + strs[1] + ">/" + strs[2];
        switch (btnType)
        {
            case E_BtnType.UP:
                inputInfo.up = path;
                break;
            case E_BtnType.DOWN:
                inputInfo.down = path;
                break;
            case E_BtnType.LEFT:
                inputInfo.left = path;
                break;
            case E_BtnType.RIGHT:
                inputInfo.right = path;
                break;
            case E_BtnType.JUMP:
                inputInfo.jump = path;
                break;
            case E_BtnType.FIRE:
                inputInfo.fire = path;
                break;
        }

        UpdateButtonInfo();//更新UI

        player.ChangeInputInfo();   //改键
    }
}
