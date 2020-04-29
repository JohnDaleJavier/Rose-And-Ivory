using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    Vector2 mouse;
    void Start(){
        Cursor.visible = false;        
    }
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouse;

    }
}
