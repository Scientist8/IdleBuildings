using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timer = 1f;

    void Start()
    {
        Destroy(gameObject, timer);
    }
}
