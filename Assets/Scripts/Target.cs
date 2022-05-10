using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager; //gamemanager scriptine ulaþmak istiyoruz
    private float minSpeed = 14;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
   
    public int pointValue;// ýnspector da objelerin puanlarýný ekle
    public ParticleSystem explosionPartical; //ýnspector da objelere renk ekle


    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed,maxSpeed);//12 ve 16 hýzlarýnda random havaya atýþ yapýyor
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque); //dönme hýzý
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); //x ve y eksenlerinde spawn aralýklarý
    }
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
        Destroy(gameObject);
        Instantiate(explosionPartical, transform.position, explosionPartical.transform.rotation);//objeyi vurduðunda renkler patlasýn
        gameManager.UpdateScore(pointValue);//targetler yok olduðunda puan ver//her objenin puaný farklý olsun

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);
        if(!gameObject.CompareTag("Bad"))//bad objesi dýþýnda herhangi bir obje sensörle buluþtuðunda gameover yazýsý çýksýn
        {
            gameManager.GameOver();
        }
    }

}
