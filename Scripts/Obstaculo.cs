using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstaculo : MonoBehaviour {
 
    void Start() {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -3f);
         
    }


    void Update () {
        if (this.transform.position.z < -25f) {
            Destroy(this.gameObject);
        }

	}
}
