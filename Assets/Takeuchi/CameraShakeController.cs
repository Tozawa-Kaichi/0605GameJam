using System;

public static class CameraShakeController
{
    public static event Action<float> OnShake = default;
    public static void PlayShake(float power)
    {
        OnShake?.Invoke(power);
    }
}
