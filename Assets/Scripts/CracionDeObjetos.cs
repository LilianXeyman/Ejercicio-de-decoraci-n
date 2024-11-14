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
       if(Input.GetMouseButton(0))
       { 
        ObjetoCreado = Instantiate(gameObject, Vector3.zero, Quaternion.identity);
       }
    }
}
