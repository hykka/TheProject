using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    protected void awake()
    {
        this._rigidbody = this.GetComponent<Rigidbody>();
        this._animator = this.GetComponentInChildren<Animator>();
    }

    void Start()
    {
        this._animator?.SetBool("Waiting", true);
    }

    void Update()
    {
        if (this._animator != null)
        {
            Debug.Log("I have no animator");
        }
    }
}
