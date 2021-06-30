using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField] float secondsDestroy;

    private void Start()
    {
        Destroy(gameObject,secondsDestroy);
    }   
}
