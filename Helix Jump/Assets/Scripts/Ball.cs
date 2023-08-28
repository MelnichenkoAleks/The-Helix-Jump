using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float bounceForce = 400f;
    public GameObject splitPrefab;

    public AudioSource audioSource;
    public AudioClip winLevelclip;
    public AudioClip gameOverclip;
    public AudioClip jumpclip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);

        GameObject newsplit = Instantiate(splitPrefab, new Vector3(transform.position.x, 
            collision.transform.position.y + 0.185f, transform.position.z),transform.rotation);

        newsplit.transform.localScale = Vector3.one * Random.Range(0.6f, 0.9f);
        newsplit.transform.parent = collision.transform;

        string marerialName =collision.transform.GetComponent<MeshRenderer> ().material.name;
        
        if (marerialName == "Safe (Instance)")
        {
            Debug.Log("You are safe");
            audioSource.PlayOneShot(jumpclip);
        }
        if (marerialName == "UnSafe (Instance)")
        {
            audioSource.PlayOneShot(gameOverclip);
            GameManager.gameOver = true;
        }
        if (marerialName == "LastRing (Instance)" && !GameManager.levelWin)
        {
            audioSource.PlayOneShot(winLevelclip);
            GameManager.levelWin = true;
        }
    }
}
