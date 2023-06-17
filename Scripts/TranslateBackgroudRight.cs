using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateBackgroudRight : MonoBehaviour {
    Vector3 initialPosition;
    float translationDistance;
    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position;
        BoxCollider bc = GetComponent<BoxCollider>();
        if(bc != null) {
            translationDistance = bc.size.x / 2;
        }        
    }

    // Update is called once per frame
    void Update() {
        if(transform.position.x < initialPosition.x - translationDistance) {
            transform.position = initialPosition;
        }
        
    }
}
