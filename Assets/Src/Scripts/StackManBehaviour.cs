using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsoCorp;

public class StackManBehaviour : MonoBehaviour
{
    private Animator _anim;
    bool isOnTop = false;
    public Material color;

    void Awake() {
        _anim = this.GetComponentInChildren<Animator>();
    }

    public void changeColor(Material color) {
        this.GetComponentInChildren<SkinnedMeshRenderer>().material = color;
    }

    public void killStackMan() {
        GetComponent<RagdollBehaviour>().EnableRagdoll(this.transform, true);
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
