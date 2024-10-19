using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        ChangeInputInfo();

        playerInput.onActionTriggered += (context) =>
        {
            if (context.phase == InputActionPhase.Performed)
            {
                switch (context.action.name)
                {
                    case "Fire":
                        print("开火");
                        break;
                    case "Jump":
                        print("跳跃");
                        break;
                    case "Move":
                        print("移动");
                        break;
                }
            }
        };
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 改键
    /// </summary>
    public void ChangeInputInfo()
    {
        playerInput.actions = DataManager.Instance.GetCurrentActionAsset();
        playerInput.actions.Enable();
    }
}
