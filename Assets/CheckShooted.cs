using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckShooted : MonoBehaviour
{
    private Animator animator;
    public ParticleSystem particlesystem;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetShooted()
    {
        animator.SetBool("Shooted", true);
        particlesystem.Play();
    }
    
    // void DoDelayAction(float delayTime)
    // {
    //     StartCoroutine(DelayAction(delayTime));
    // }

    // IEnumerator DelayAction(float delayTime)
    // {
    //     //Wait for the specified delay time before continuing.
    //     yield return new WaitForSeconds(delayTime);
        

    //     //Do the action after the delay time has finished.
    // }
}


