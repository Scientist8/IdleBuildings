using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timer = 1f;
    [SerializeField] float timeElapsed = 0f;

    void Start()
    {
        // Destroy(gameObject, timer);
    }

    void Update()
    {
        // For pooled objects
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timer)
        {
            gameObject.SetActive(false);
            timeElapsed = 0f;
        }
    }
}
