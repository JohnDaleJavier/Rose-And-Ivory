using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerLogic : MonoBehaviour
{
    public int sortingOrderOffset;
    void Update()
    {
        gameObject.GetComponent<Renderer>().sortingOrder = (Mathf.RoundToInt(-transform.position.y * 10) + sortingOrderOffset);
    }
}
