using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{
    public Collider spawnArea;
    public float length;
    public float targetXValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Oscillate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //var foodItem = collision.gameObject.GetComponent<XRGrabInteractable>();

        //if (foodItem != null)
        //{
        //    ChangeTargetPosition();
        //    GameManager.Instance.SpawnFoodItem();
        //}

        if (collision.gameObject.CompareTag("Food"))
        {
            ChangeTargetPosition();
            GameManager.Instance.SpawnFoodItem();
        }
    }

    void ChangeTargetPosition()
    {
        float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        float z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

        transform.position = new Vector3(x, y, z);
    }

    void Oscillate()
    {
        targetXValue = Mathf.PingPong(Time.time, length);
        transform.position = new Vector3(targetXValue, transform.position.y, transform.position.z);
    }
}
