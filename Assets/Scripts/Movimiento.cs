using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
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
    bool vaAMover;

  
    void Update()
    {
        if (vaAMover)
        {
            objetoSeleccionado.SetActive(false);
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayo, out hit))
            {
                Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
                objetoSeleccionado.transform.position = hitPoint;
            }
            objetoSeleccionado.SetActive(true);
            if (Input.GetMouseButtonUp(1))
            {
                vaAMover = false;
            }
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objetoSeleccionado = this.gameObject;
            Debug.Log("Objeto seleccionado para mover: " + objetoSeleccionado.name);
        }
    }
    public void Mover()
    {
       
        LeanTween.moveLocalY(popUpMenu, 0, 1f).setEase(animeCurv);
        popUpComoSeUsa.SetActive(true);
        LeanTween.scale(popUpComoSeUsa, Vector3.one * multiDelV3e, tiempoAnimacion).setOnComplete(() => {
            LeanTween.scale(popUpComoSeUsa, Vector3.one * multiDelV3, tiempoAnimacion);
        });
        vaAMover = true;
    }
}
