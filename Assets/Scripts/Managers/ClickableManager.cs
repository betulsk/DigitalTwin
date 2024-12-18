using System;
using System.Collections;
using UnityEngine;

public class ClickableManager : Singleton<ClickableManager>
{
    private Coroutine _coroutine;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _maxRayDistance;

    public BaseClickable LastClickableObj;

    public Action<BaseClickable> OnClickableClicked;

    private void Awake()
    {
        _coroutine = StartCoroutine(ClickRoutine());
    }

    private void OnDestroy()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator ClickRoutine()
    {
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(TryClick())
                {
                }
            }
            yield return null;
        }
    }

    private bool TryClick()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, _maxRayDistance, _layerMask))
        {
            BaseClickable clickable = raycastHit.collider.GetComponent<BaseClickable>();
            if(clickable != null)
            {
                Debug.Log($"Clickable: {clickable.gameObject.name}");
                clickable.Click();
                LastClickableObj = clickable;
                OnClickableClicked?.Invoke(clickable);
                return true;
            }
        }
        return false;
    }
}

