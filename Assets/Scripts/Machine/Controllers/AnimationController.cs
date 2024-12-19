using DG.Tweening;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Tween _punchTween;
    [SerializeField] private Transform _uiTransform;
    [SerializeField] private Vector3 _punchVector;
    [SerializeField] private float _punchDuration = 0.3f;

    private void Start()
    {
        InputManager.OnPressedKey += OnPressedKey;
    }

    private void OnDestroy()
    {
        InputManager.OnPressedKey -= OnPressedKey;
        _punchTween.Kill();
    }

    private void OnPressedKey(KeyCode keyCode)
    {
        if(keyCode == KeyCode.A)
        {
            if(_punchTween != null)
            {
                _punchTween.Kill();
                _uiTransform.localScale = Vector3.one;
            }
            _punchTween = _uiTransform.DOPunchScale(_punchVector, _punchDuration);
        }
    }
}
