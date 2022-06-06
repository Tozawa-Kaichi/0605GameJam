using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    [SerializeField]
    private Text _text = default;
    private int _count = 0;
    public int Count 
    { 
        set
        { 
            _count = value;
            if (_count < 0)
            {
                _count = 0;
            }
            ShowCount();
        } 
    }
    private void ShowCount()
    {
        _text.text = _count.ToString();
    }
}
