using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSortingLayerLogic : MonoBehaviour
{
    public GameObject player;
    public int sortingOrderOffset;
    void Update()
    {
        gameObject.GetComponent<Renderer>().sortingOrder = ((player.GetComponent<Renderer>().sortingOrder) + sortingOrderOffset);
    }
    
}
