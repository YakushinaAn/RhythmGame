using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public NotesScroller ntScroller;
    public GameObject thisnote;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    void Start()
    {

        ntScroller = FindObjectOfType(typeof(NotesScroller)) as NotesScroller;
        
    }
    
    void Update()
    {
        transform.position -= new Vector3(0f, ntScroller.notesTempo * Time.deltaTime, 0f);

        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);


                if(Mathf.Abs(transform.position.y) > 0.25f)
                {
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && thisnote.activeSelf)
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
