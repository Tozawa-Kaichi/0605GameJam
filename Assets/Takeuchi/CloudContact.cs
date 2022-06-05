using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudContact : MonoBehaviour
{
    [SerializeField]
    private CloudController _cloudController = default;
    public void StartThundercloud()
    {
        _cloudController.StartThundercloud();
    }
    public void AddSize(float size)
    {
        _cloudController.AddSize(size);
    }
}
