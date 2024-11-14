using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CracionDeObjetos : MonoBehaviour
{
    GameObject ObjetoCreado;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void BotonObjeto()
    {
       
        ObjetoCreado = Instantiate(gameObject, Vector3.zero, Quaternion.identity);
       
    }
}
