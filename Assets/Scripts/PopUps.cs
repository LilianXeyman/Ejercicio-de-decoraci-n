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

    //Para la creación de los objetos se hará una lista (array) con todos ellos. 
    public GameObject[] ObjetoCreado;
    GameObject objetoSeleccionado;
    GameObject objetoCreadoDeVerdad;
    int selectedItem;
    /*[SerializeField]
    float posicionObjetos;*/
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PopUpMenu()
    {
        movimientoInicialObjetos = 0;
        LeanTween.moveLocalY(objetos, movimientoInicialObjetos, 1f).setEase(animeCurv).setOnComplete(() => {
            LeanTween.moveLocalX(popUpCreacionObjetos, 1185, 1f).setEase(animeCurv).setOnComplete(() => {
                popUpCreacionObjetos.SetActive(false);
            });
            LeanTween.moveLocalY(gameObject, posicionFinal, 1f).setEase(animeCurv);
        });
    }
    public void Crear()
    {
        popUpCreacionObjetos.SetActive(true);
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv).setOnComplete(() => {
            movimientoInicialObjetos = 1000;
            LeanTween.moveLocalX(popUpCreacionObjetos, posicionPopUpCreaObj, 1f).setEase(animeCurv).setOnComplete(() => {
                LeanTween.moveLocalY(objetos, 1000, 1f).setEase(animeCurv);
            });
        });


    }
    public void Subir()
    {
        if (movimientoInicialObjetos >= 6900)
        {
            movimientoInicialObjetos = 7000;
            LeanTween.moveLocalY(objetos, movimientoInicialObjetos, 1f).setEase(animeCurv);
        }
        else
        {
            movimientoInicialObjetos = movimientoInicialObjetos + 1000;
            LeanTween.moveLocalY(objetos, movimientoInicialObjetos, 1f).setEase(animeCurv);//Me quede por aquí. El objetivo es que suban los objetos y se coloquen en el menú de cración de objetos
        }
    }
    public void Bajar()
    {

        if (movimientoInicialObjetos <= 1100)
        {
            movimientoInicialObjetos = 1000;
            LeanTween.moveLocalY(objetos, movimientoInicialObjetos, 1f).setEase(animeCurv);
        }
        else
        {
            movimientoInicialObjetos = movimientoInicialObjetos - 1000;
            LeanTween.moveLocalY(objetos, movimientoInicialObjetos, 1f).setEase(animeCurv);
        }
    }
    public void RetornadorDeBotellas()
    {
        selectedItem = 0;
        BotonObjeto();
    }
    public void CajaRegistradora()
    {
        selectedItem = 1;
        BotonObjeto();
    }
    public void Cliente()
    {
        selectedItem = 2;
        BotonObjeto();
    }
    public void EstanteDePan()
    {
        selectedItem = 3;
        BotonObjeto();
    }
    public void Fruta()
    {
        selectedItem = 4;
        BotonObjeto();
    }
    public void Valla()
    {
        selectedItem = 5;
        BotonObjeto();
    }
    public void Puertas()
    {
        selectedItem = 6;
        BotonObjeto();
    }
    public void Congelador1()
    {
        selectedItem = 7;
        BotonObjeto();
    }
    public void RCongelador2()
    {
        selectedItem = 8;
        BotonObjeto();
    }
    public void Estanteria1()
    {
        selectedItem = 9;
        BotonObjeto();
    }
    public void Estanteria2()
    {
        selectedItem = 10;
        BotonObjeto();
    }
    public void Estanteria3()
    {
        selectedItem = 11;
        BotonObjeto();
    }
    public void BolsaDeLaCompra()
    {
        selectedItem = 12;
        BotonObjeto();
    }
    public void Carrito()
    {
        selectedItem = 13;
        BotonObjeto();
    }
    public void Botella()
    {
        selectedItem = 14;
        BotonObjeto();
    }
    public void Botella2()
    {
        selectedItem =15;
        BotonObjeto();
    }
    public void Caja1()
    {
        selectedItem = 16;
        BotonObjeto();
    }
    public void Caja2()
    {
        selectedItem = 17;
        BotonObjeto();
    }
    public void Caja3()
    {
        selectedItem = 18;
        BotonObjeto();
    }
    public void Caja4()
    {
        selectedItem = 19;
        BotonObjeto();
    }
    public void BotonObjeto()
    {

        objetoCreadoDeVerdad = Instantiate(ObjetoCreado[selectedItem], new Vector3 (11.5f,2.5f,3.26f), Quaternion.identity);

    }
}
