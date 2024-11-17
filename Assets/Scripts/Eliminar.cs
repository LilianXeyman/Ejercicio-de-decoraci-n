using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliminar : MonoBehaviour
{
    [SerializeField]
    LeanTweenType animeCurv;
    [SerializeField]
    GameObject popUpMenu;
    [SerializeField]
    GameObject popUpComoSeUsa;

    [SerializeField]
    float tiempoAnimacion = 0.5f;

    [SerializeField]
    float multiDelV3e = 0.5f;

    [SerializeField]
    float multiDelV3 = 2f;
    GameObject objetoSeleccionado;
    bool vaAEliminar;

    
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("Seleccion"))
                {
                    objetoSeleccionado = hit.transform.gameObject;
                    Debug.Log("Objeto seleccionado: " + objetoSeleccionado.name);
                }
            }
        }
        if (vaAEliminar)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(objetoSeleccionado);
                vaAEliminar = false;
            }
        }
    }
    // Update is called once per frame
    public void Borrar()
    {
       
        LeanTween.moveLocalY(popUpMenu, 0, 1f).setEase(animeCurv);
        popUpComoSeUsa.SetActive(true);
        LeanTween.scale(popUpComoSeUsa, Vector3.one * multiDelV3e, tiempoAnimacion).setOnComplete(() => {
            LeanTween.scale(popUpComoSeUsa, Vector3.one * multiDelV3, tiempoAnimacion);
        });
        vaAEliminar = true;
    }
}
