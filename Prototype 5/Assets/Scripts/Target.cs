using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Private Variables
    private Rigidbody targetRb;
    private float minSpeed = 16;
    private float maxSpeed = 19;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManager gameManager;

    // Public Variables
    public int pointValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    // Ready the objects' rigidbody, amount of force and torque, spawn position, and instantiate gameManager for game over.
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Speed of the objects going up
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Force rotation value of the objects going up
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Positions where the objects will spawn
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Once you clicked the objects(good/bad), it wil be destroyed and will have an explosion effect, and the score will update depending on the objects
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    // If you missed to destroy the good object/s, the game will be over
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
