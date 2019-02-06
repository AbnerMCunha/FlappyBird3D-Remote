using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Principal : MonoBehaviour {

    public GameObject cerca;
    public GameObject arbusto;
    public GameObject pedra;
    public GameObject canos;
    public GameObject nuvem;

    public GameObject player;

    public bool comecou;
    public bool acabou;

    public int ponto;
    public Text pontuacao;

    public AudioClip somVoa;

    private void Start() {

        Physics.gravity = new Vector3(0, -40, 0);
    }

    void Update() {
        if (Input.anyKeyDown) {
            if (!acabou) {
                if (!comecou) {
                    pontuacao.text = ponto.ToString();

                    comecou = true;
                    InvokeRepeating("CriaCerca", 1, .71f);
                    InvokeRepeating("CriaObstaculo", 1.8f, 1f);

                    player.GetComponent<Rigidbody>().useGravity = true;
                    player.GetComponent<Rigidbody>().isKinematic = false;
                }   
            }
            VoaFelps(acabou);
        }
        player.GetComponent<Transform>().rotation = Quaternion.Euler(player.GetComponent<Rigidbody>().velocity.y * -3, 0f, 0f);
    }

    public void VoaFelps(bool acabou) {
        if (!acabou) {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
            player.GetComponent<AudioSource>().PlayOneShot(somVoa);
        }
        else {
            AcabaJogo();
        }
    }

    public void AcabaJogo() {
        acabou = true;

        print("aaaaaa");
        Invoke("RecarregaCena", 2f);
    }

    public void RecarregaCena() {
        CancelInvoke("CriaCerca");
        CancelInvoke("CriaObstaculo");
        Application.LoadLevel("SampleScene");
    }

    public void CriaCerca() {
        Instantiate(cerca);

    }

    public void CriaObstaculo() {

        int sorteiNum = Random.Range(1, 7);
        print(sorteiNum);
        float posXrandom = Random.Range(-2.25F, 1.85F);
        float posYrandom = Random.Range(2.4f, 4.8f);
        //  float rotYrandom = Random.Range(0f, 360f);

        GameObject novoGO = new GameObject();

        switch (sorteiNum) {
            case 1: novoGO = Instantiate(arbusto); posYrandom = novoGO.transform.position.y; break;
            case 2: novoGO = Instantiate(pedra); posYrandom = novoGO.transform.position.y; break;
            case 3: novoGO = Instantiate(nuvem); break;
            case 4: novoGO = Instantiate(canos); posYrandom = Random.Range(-1.33f, 0.8f);
                posXrandom = novoGO.transform.position.x;
                //      rotYrandom = novoGO.transform.rotation.y;
                break;
            case 5:
                novoGO = Instantiate(canos); posYrandom = Random.Range(-1.64f, 0.7f);
                posXrandom = novoGO.transform.position.x; break;
            //    rotYrandom = novoGO.transform.rotation.y;


            case 6:
                novoGO = Instantiate(canos); posYrandom = Random.Range(-1.64f, 0.7F);
                posXrandom = novoGO.transform.position.x;
                //qc  rotYrandom = novoGO.transform.rotation.y;
                break;

            default: break;
        }

        novoGO.transform.position = new Vector3(posXrandom, posYrandom, transform.position.z + 10);
        //  novoGO.transform.rotation = Quaternion.Euler(novoGO.transform.rotation.x, rotYrandom, novoGO.transform.rotation.y);
    }


    public void MarcaPonto() {
        ponto++;

        pontuacao.text = ponto.ToString();


    }
}
