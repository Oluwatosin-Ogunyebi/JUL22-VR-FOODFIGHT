using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class Target : MonoBehaviour
{
    public Collider spawnArea;
    AudioSource audioSource;
    public AudioClip hitSound;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public float destroyDelay;
    private void OnCollisionEnter(Collision collision)
    {
        var foodCollidedWith = collision.gameObject.GetComponent<XRGrabInteractable>();

        if (foodCollidedWith != null && GameManager.Instance.checkGameRunning())
        {
            audioSource.PlayOneShot(hitSound);
            Destroy(collision.gameObject, destroyDelay);
            ChangeTargetPosition(spawnArea);

            GameManager.Instance.AddScore();
            GameManager.Instance.SpawnFoodItem();
        }

    }

    private void ChangeTargetPosition(Collider area)
    {
        float x = Random.Range(area.bounds.min.x, area.bounds.max.x);
        float y = Random.Range(area.bounds.min.y, area.bounds.max.y);
        float z = Random.Range(area.bounds.min.z, area.bounds.max.z);
        
        transform.position = new Vector3(x, y, z);
    }
}
