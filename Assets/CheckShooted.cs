using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckShooted : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public ParticleSystem particlesystem;

    public float speed = 5f;

    private float changeDirectionDelay = 1;
    private float timeOfLastChange = 0;

    private Vector3 direction;

    private bool shooted = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        if (!shooted)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            if (Time.time - timeOfLastChange > changeDirectionDelay || timeOfLastChange == 0)
            {
                timeOfLastChange = Time.time;
                direction = new Vector3(randomX, 0, randomY);
            }
            ;
            if (Random.Range(1, 100) == 5) changeDirectionDelay = Random.Range(5, 50) / 10f; // change direction delay if 1 in 10 chance

            rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);
        }

    }

    public void SetShooted()
    {
        animator.SetInteger("Shooted", 1);
        particlesystem.Play();
        StartCoroutine(DelayShooted(1));
        shooted = true;
        GetComponent<CapsuleCollider>().enabled = false;
        rigidbody.constraints = RigidbodyConstraints.FreezePosition;
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


