using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintScript : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("char run-sprint animation1 152x32_0");
    }
}
