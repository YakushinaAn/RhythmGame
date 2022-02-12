using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    //[SerializeField] public Sprite currentSprite;
    public Sprite defaultStateImg;
    public Sprite pressedStateImg;

    public KeyCode KeyToPress;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            _spriteRenderer.sprite = pressedStateImg;
        }
        if (Input.GetKeyUp(KeyToPress))
        {
            _spriteRenderer.sprite = defaultStateImg;
        }
    }
}
