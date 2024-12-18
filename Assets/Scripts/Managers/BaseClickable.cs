using UnityEngine;

public abstract class BaseClickable : MonoBehaviour
{
    public abstract void ClickCustomActions();

    public void Click()
    {
        ClickCustomActions();
    }
}

