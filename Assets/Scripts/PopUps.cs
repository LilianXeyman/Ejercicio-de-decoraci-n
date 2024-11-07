using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUps : MonoBehaviour
{
    [SerializeField]
    float posicionFinal;
    [SerializeField]
    LeanTweenType animeCurv;
    [SerializeField]
    GameObject popUpCreacionObjetos;
    [SerializeField]
    float posicionPopUpCreaObj;
    [SerializeField]
    float movimientoInicialObjetos;
    [SerializeField]
    GameObject objetos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PopUpMenu()
    {
        LeanTween.moveLocalY(gameObject, posicionFinal, 1f).setEase(animeCurv);
        LeanTween.moveLocalX(popUpCreacionObjetos, 1185, 1f).setEase(animeCurv).setOnComplete(() => {
            popUpCreacionObjetos.SetActive(false);
        });
        
    }
    public void Crear()
    {
        popUpCreacionObjetos.SetActive(true);
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv).setOnComplete(()=> { 
        LeanTween.moveLocalX(popUpCreacionObjetos, posicionPopUpCreaObj, 1f).setEase(animeCurv);
        });
        
        
    }
    public void Subir()
    {
        movimientoInicialObjetos = movimientoInicialObjetos + 1000;
        LeanTween.moveLocalY(objetos, movimientoInicialObjetos, 1f).setEase(animeCurv);//Me quede por aqu�. El objetivo es que suban los objetos y se coloquen en el men� de craci�n de objetos
    }
    public void Bajar()
    {
        movimientoInicialObjetos = movimientoInicialObjetos - 1000;
        LeanTween.moveLocalY(objetos, movimientoInicialObjetos, 1f).setEase(animeCurv);
    }
    public void Rotar()
    {
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv);
    }
    public void Mover()
    {
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv);
    }
    public void Eliminar()
    {
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv);
    }

}
