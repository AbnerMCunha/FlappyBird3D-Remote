using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFelpudo : MonoBehaviour {

    public bool acabou;
    public AudioClip somBate;
    public AudioClip somPonto;



    void Start () {

    }
	
    private void OnTriggerEnter(Collider other) {
         

        if (other.gameObject.tag ==  "Finish") {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = new Vector3(10, 6, 5);
            GetComponent<Rigidbody>().AddTorque( new Vector3( 10.0f, 10.0f, -200.0f));       
            GetComponent<AudioSource>().PlayOneShot(somBate);

            Camera.main.SendMessage("AcabaJogo");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag =="GameController" ) {
            Destroy(other.gameObject, 3f);
            Camera.main.GetComponent<Principal>().MarcaPonto();
            GetComponent<AudioSource>().PlayOneShot(somBate);

        }
    }
}
