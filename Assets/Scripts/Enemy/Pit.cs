using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : Enemy
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1 -1;
    }
}
