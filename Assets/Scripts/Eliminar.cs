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
        if (vaAEliminar)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(objetoSeleccionado);
            }
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objetoSeleccionado = this.gameObject;
            Debug.Log("Objeto seleccionado para eliminar: " + objetoSeleccionado.name);
        }
    }
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
