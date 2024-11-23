using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sea : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Vector2 offsetDirection = new Vector2(1, 0);
    [SerializeField] private float duration = 0.5f; 

    private void Start()
    {
        _material.DOOffset(Vector2.zero,0);
        if (_material == null)
        {
            Debug.LogError("Material is not assigned!");
            return;
        }

        _material.DOOffset(offsetDirection, duration)
                 .SetEase(Ease.InOutSine) // Adjust easing as needed
                 .SetLoops(-1,LoopType.Yoyo); // Infinite loop with yoyo effect
    }
}
