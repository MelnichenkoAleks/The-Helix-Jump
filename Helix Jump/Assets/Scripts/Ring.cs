using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;
    public GameObject[] childRings;

    private AudioSource audioSource;
    public AudioClip whooshclip;

    float radius = 100f;
    float force = 300f;

    void Start()
    {
        player= GameObject.FindGameObjectWithTag ("Player").transform;
        audioSource = GameObject.FindGameObjectWithTag ("Sound").GetComponent<AudioSource> ();
    }

    private void Update()
    {
        if (transform.position.y > player.position.y)
        {
            GameManager.noOfPassingRings ++;
            for(int i=0; i<childRings.Length; i++)
            {
                childRings[i].GetComponent<Rigidbody>().isKinematic = false;
                childRings[i].GetComponent<Rigidbody>().useGravity = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

                foreach (Collider newcollider in colliders)
                {
                    Rigidbody rb = newcollider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(force, transform.position, radius);
                        audioSource.clip = whooshclip;
                        audioSource.Play();
                    }
                }

                childRings[i].GetComponent<MeshCollider>().enabled = false;
                childRings[i].transform.parent = null;
                Destroy (childRings[i].gameObject, 2f);
                Destroy(this.gameObject, 5f);
            }
            this.enabled = false;
        }
    }
}
