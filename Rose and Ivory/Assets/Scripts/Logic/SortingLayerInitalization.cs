using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerInitalization : MonoBehaviour
{
    public int sortingOrderOffset;
    void Start()
    {
        gameObject.GetComponent<Renderer>().sortingOrder = (Mathf.RoundToInt(-transform.position.y * 10) + sortingOrderOffset); 
    }
}
