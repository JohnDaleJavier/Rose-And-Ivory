using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerLogic : MonoBehaviour
{
    void FixedUpdate()
    {
        gameObject.GetComponent<Renderer>().sortingOrder = Mathf.RoundToInt(-transform.position.y * 10);
    }
}
