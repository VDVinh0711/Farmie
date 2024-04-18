using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/*
public abstract class AbsCheckOutSide : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    [SerializeField] protected bool _isOutSide = false;
    protected FarmInputAction _farmInputAction;

    protected virtual void Awake()
    {
        _farmInputAction = new FarmInputAction();
        _farmInputAction.Enable();
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        _isOutSide = true;
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        _isOutSide = false;
    }

    protected virtual void regisclick()
    {
        _farmInputAction.InteracPlayer.Click.performed += Click;
    }

    protected virtual void Click(InputAction.CallbackContext obj)
    {
        if (_isOutSide)
        {
            gameObject.SetActive(false);
            RemoveClick();
        }
    }

    protected virtual void RemoveClick()
    {
        _farmInputAction.InteracPlayer.Click.performed -= Click;
    }
}
*/
