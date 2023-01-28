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

    private float _pressedTime = 0;
    public float _interval = 0.5f;

    public void OnUpdate()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        //우버튼 클릭
        if (Input.GetMouseButtonDown(0))
        {
            _pressed = true;
            _pressedTime = Time.time;

        }

        if (Input.GetMouseButtonUp(0))
        {
            //1초 이상 눌른경우는 우클릭 처리
            if (Time.time - _pressedTime < _interval)
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D ray = new Ray2D(new Vector2(mouseWorldPos.x, mouseWorldPos.y), Vector3.zero);
                RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction);

                if (rayHit.collider != null)
                {
                    if (rayHit.collider.gameObject.tag.Equals("Cell"))
                    {
                        CellController controller = rayHit.collider.gameObject.GetComponent<CellController>();
                        if (controller != null)
                        {
                            controller.OnMouseLClick();
                        }
                    }
                }
            }
            else
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D ray = new Ray2D(new Vector2(mouseWorldPos.x, mouseWorldPos.y), Vector3.zero);
                RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction);

                if (rayHit.collider != null)
                {
                    if (rayHit.collider.gameObject.tag.Equals("Cell"))
                    {
                        CellController controller = rayHit.collider.gameObject.GetComponent<CellController>();
                        if (controller != null)
                        {
                            controller.OnMouseRClick();
                        }
                    }
                }
            }

            _pressedTime = 0f;
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
