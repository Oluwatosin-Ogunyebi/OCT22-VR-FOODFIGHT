using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Food : MonoBehaviour
{
    public AudioClip foodAudioClip;
    private AudioSource foodAudioSource;
    [SerializeField] private int delay;
    // Start is called before the first frame update
    void Start()
    {
        foodAudioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //var target = collision.gameObject.GetComponent<Target>();
        //if (target != null)
        //{
        //    foodAudioSource.PlayOneShot(foodAudioClip);
        //    Destroy(this.gameObject, delay);
        //}
        if (collision.gameObject.CompareTag("Target"))
        {
            foodAudioSource.PlayOneShot(foodAudioClip);
            Destroy(this.gameObject, delay);
        }
    }

    public void DestroyAfterDelay(int foodWaitTime)
    {
        Invoke("SpawnFood", foodWaitTime);
        Destroy(this.gameObject, foodWaitTime);
    }

    void SpawnFood()
    {
        GameManager.Instance.SpawnFoodItem();
    }
}
