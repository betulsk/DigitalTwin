using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void KeyCodeEvents(KeyCode keyCode);

    public static event KeyCodeEvents OnPressedKey;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            OnPressedKey?.Invoke(KeyCode.X);
        }
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            OnPressedKey?.Invoke(KeyCode.A);
        }
    }
}
