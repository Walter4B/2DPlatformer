using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public KeyColor KeyTypeToUnlock = KeyColor.Red;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        Key.OnKeyPickedUp.AddListener(Unlock);
    }

    private void Unlock(KeyColor keyType)
    {
        if (keyType != KeyTypeToUnlock)
            return;

        Color color = _spriteRenderer.color;
        color.a = 0.5f;
        _spriteRenderer.color = color;

        _boxCollider2D.enabled = false;
    }
}
