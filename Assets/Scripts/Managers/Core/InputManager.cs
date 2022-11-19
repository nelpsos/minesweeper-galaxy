using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    public bool _pressed = false;
    public bool _RPress = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (MouseAction != null)
        {
            
            if (Input.GetMouseButton(0))
            {
                //좌 버튼 다운
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else if(Input.GetMouseButton(1))
            {
                //우버튼 클릭
                MouseAction.Invoke(Define.MouseEvent.RPress);
                _RPress = true;
            }
            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;

                if(_RPress)
                    MouseAction.Invoke(Define.MouseEvent.RClick);
                _RPress = false;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
