using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CracionDeObjetos : MonoBehaviour
{
    public GameObject[] ObjetoCreado;

    PopUps popUps;
    [SerializeField]
    GameObject objetos;
    [SerializeField]
    LeanTweenType animeCurv;
    [SerializeField]
    GameObject popUpCreacionObjetos;
    GameObject objetoSeleccionado;
    GameObject objetoCreadoDeVerdad;
    int selectedItem;
    // Start is called before the first frame update
    void Start()
    {
        
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
        selectedItem = 15;
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
        objetoCreadoDeVerdad = Instantiate(ObjetoCreado[selectedItem], new Vector3(11.5f, 2.5f, 3.26f), Quaternion.identity);
        LeanTween.moveLocalY(objetos, 0, 1f).setEase(animeCurv).setOnComplete(() => {
            LeanTween.moveLocalX(popUpCreacionObjetos, 1500, 1f).setEase(animeCurv);
        });

        objetoCreadoDeVerdad.SetActive(false);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
            objetoCreadoDeVerdad.transform.position = hitPoint;
        }
        objetoCreadoDeVerdad.SetActive(true);




    }
    // Update is called once per frame

}
