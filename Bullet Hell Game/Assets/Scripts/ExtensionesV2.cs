using UnityEngine;

public static class ExtensionesV2
{
    public static Vector2 Rotate(this Vector2 vecOriginal, float anguloGrados)
    {
        Quaternion rotarion = Quaternion.AngleAxis(anguloGrados, Vector3.forward);
        return rotarion * vecOriginal;  
    }
}
