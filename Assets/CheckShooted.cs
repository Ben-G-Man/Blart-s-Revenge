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
        transform.LookAt(Camera.main.transform);

    }

    public void SetShooted()
    {
        animator.SetInteger("Shooted", 1);
        particlesystem.Play();
        StartCoroutine(DelayShooted(1));
        // StartCoroutine(DelayDestroy(4));
    }

    IEnumerator DelayShooted(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        animator.SetInteger("Shooted", 2);

        GetComponent<CapsuleCollider>().height = 0.5f;
        GetComponent<CapsuleCollider>().center = new Vector3(0, -0.25f, 0);

        //Do the action after the delay time has finished.
    }
    IEnumerator DelayDestroy(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);

        //Do the action after the delay time has finished.
    }
}


