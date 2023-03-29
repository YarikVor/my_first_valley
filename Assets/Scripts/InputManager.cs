using UnityEngine;

public static class InputManager
{
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
    
    public static float HorisontalAxisRow => Input.GetAxisRaw(Horizontal);
    public static float VerticalAxisRow => Input.GetAxisRaw(Vertical);
    
}