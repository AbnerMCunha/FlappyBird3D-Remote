using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaPiso : MonoBehaviour {

    public Material mat;
    public float velocidade = 0.55f;

    void Update () {
        float offset = Time.time * velocidade;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));	
	}
}
