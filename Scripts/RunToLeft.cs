using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToLeft : MonoBehaviour {
    public float speed = 12;

    // Update is called once per frame
    void Update()  {
        if(GameManager.instance.IsGameOver) {
            return;
        }
    
        transform.position -= transform.right * speed * Time.deltaTime;
        
    }
}
