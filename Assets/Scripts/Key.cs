using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public enum KeyColor
{
    Red,
    Blue,
    Green,
    Yellow
}

public class KeyPickedUpEvent : UnityEvent<KeyColor> { }

public class Key : MonoBehaviour
{
    [System.Serializable]
    public class KeyTypeSprite
    {
        public KeyColor KeyType;
        public Sprite KeySprite;
    }

    public List<KeyTypeSprite> KeyTypeSpritePairs;
    public KeyColor KeyType = KeyColor.Red;

    public static KeyPickedUpEvent OnKeyPickedUp = new KeyPickedUpEvent();

    private void Awake()
    {
        foreach (KeyTypeSprite keyTypeSprite in KeyTypeSpritePairs)
        {
            if (KeyType == keyTypeSprite.KeyType)
                //Ovo nikak ne valja radit
                GetComponent<SpriteRenderer>().sprite = keyTypeSprite.KeySprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Key picked up: " + KeyType);

            OnKeyPickedUp.Invoke(KeyType);

            Destroy(gameObject);
        }
    }
}
