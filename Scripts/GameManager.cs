using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private List<GameObject> barrierPool;

    public GameObject barrierPrefab;
    private Vector3 barrierSpawnPoint = new Vector3(30, 1, 0);

    private bool gameOver = false;
    public bool IsGameOver { get{ return gameOver; } }

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnBarriers());     
        barrierPool = new List<GameObject>();   
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void GameOver() {
        gameOver = true;
    }

    public void DeactivateBarrier(GameObject barrier) {
        //Guardamos la barrera en el pool de desactivadas
        barrierPool.Add(barrier);
        //Desactivamos la barrera
        barrier.SetActive(false);
    }

    IEnumerator SpawnBarriers() {
        while( ! gameOver) {
            float timeToSleep = 1f + Random.Range(0f, 3f);
            yield return new WaitForSeconds(timeToSleep);
            //Comprobamos si hay algunha barrera disponible el en pool de desactivadas
            if(barrierPool.Count > 0) {
                //Si la hay la activamos, la reubicamos en el punto de espaneo
                GameObject barrier = barrierPool[0];
                barrier.transform.position = barrierSpawnPoint;
                barrier.transform.rotation = Quaternion.identity;
                barrier.GetComponent<Rigidbody>().velocity = Vector3.zero;
                barrier.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                barrier.SetActive(true);

                //y la sacamos del pool
                barrierPool.RemoveAt(0);
            } else {             
                //Si no hay barreras disponibles, espaneamos una nueva
                Instantiate(barrierPrefab, barrierSpawnPoint, Quaternion.identity);
            }
        }

    }
}
