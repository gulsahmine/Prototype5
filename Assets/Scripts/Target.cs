using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager; //gamemanager scriptine ula�mak istiyoruz
    private float minSpeed = 14;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
   
    public int pointValue;// �nspector da objelerin puanlar�n� ekle
    public ParticleSystem explosionPartical; //�nspector da objelere renk ekle


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
        return Vector3.up * Random.Range(minSpeed,maxSpeed);//12 ve 16 h�zlar�nda random havaya at�� yap�yor
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque); //d�nme h�z�
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); //x ve y eksenlerinde spawn aral�klar�
    }
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
        Destroy(gameObject);
        Instantiate(explosionPartical, transform.position, explosionPartical.transform.rotation);//objeyi vurdu�unda renkler patlas�n
        gameManager.UpdateScore(pointValue);//targetler yok oldu�unda puan ver//her objenin puan� farkl� olsun

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);
        if(!gameObject.CompareTag("Bad"))//bad objesi d���nda herhangi bir obje sens�rle bulu�tu�unda gameover yaz�s� ��ks�n
        {
            gameManager.GameOver();
        }
    }

}
