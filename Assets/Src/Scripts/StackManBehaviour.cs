using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsoCorp;

public class StackManBehaviour : MonoBehaviour
{
    private Animator _anim;
    bool isOnTop = false;

    void Awake() {
        _anim = this.GetComponentInChildren<Animator>();
    }

    public void killStackMan(Transform killer) {
        GetComponent<RagdollBehaviour>().EnableRagdoll(killer);
    }

    public void looseBalance(bool looseBalance) {
        if (isOnTop) {
            _anim.SetBool("LoosingBalance", looseBalance);
        }
    }

    public void StackManOnTop(bool onTop) {
        _anim.SetBool("OnTop", onTop);
        isOnTop = onTop;
    }
}
