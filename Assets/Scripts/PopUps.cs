using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopUps : MonoBehaviour
{
    //Variables para los popUps
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
    bool popUpMenu1;

    //Para la creación de los objetos se hará una lista (array) con todos ellos. 
    public GameObject[] ObjetoCreado;
    GameObject objetoSeleccionado;
    GameObject objetoCreadoDeVerdad;
    int selectedItem;

    //Aqui se ponen los popUps que se van a emplear como fuente de información
    [SerializeField]
    GameObject popUpInfoMover;
    [SerializeField]
    GameObject popUpInfoRotar;
    [SerializeField]
    GameObject popUpInfoEliminar;

    [SerializeField]
    float tiempoAnimacion = 0.5f;

    [SerializeField]
    float multiDelV3e = 0.75f;

    [SerializeField]
    float multiDelV3 = 1f;

    //Bool para saber si se está moviendo un objeto, eliminarlo y rotarlo
    bool moviendoObjeto;
    bool vaAMover = false;
    bool estaRotando = false;
    bool vaAEliminar = false;

    void Start()
    {
        moviendoObjeto = false;
        vaAMover = false;
        estaRotando=false;
        vaAEliminar=false;
        popUpMenu1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (moviendoObjeto == true && objetoCreadoDeVerdad !=null)
        {
            objetoCreadoDeVerdad.SetActive(false);
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayo, out hit))
            {
                Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
                objetoCreadoDeVerdad.transform.position = hitPoint;
            }
            objetoCreadoDeVerdad.SetActive(true);
            if (Input.GetMouseButtonUp(0))
            {
                moviendoObjeto = false;
            }
        }*/
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
        //Este es el UpDate para Rotar
        if (estaRotando == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                objetoSeleccionado.transform.Rotate(0, -1, 0);
            }
            if (Input.GetKey(KeyCode.E))
            {
                objetoSeleccionado.transform.Rotate(0, 1, 0);
            }
            /*if (Input.GetMouseButtonDown(1))
            {
                estaRotando = false;
            }*/
        }
        //Este es el Update para Eliminar
        if (vaAEliminar)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(objetoSeleccionado);
                //vaAEliminar = false;
            }
        }
        //Este es el Update para Mover los objetos
        if (vaAMover)//Mirar esto para mejorar
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
                LeanTween.scale(popUpInfoMover, Vector3.one * multiDelV3, tiempoAnimacion).setOnComplete(() =>
                {
                    popUpInfoMover.SetActive(false);
                });
                
            }
        }
    }
    public void PopUpMenu()
    {
        if (popUpMenu1 == true)
        {
            movimientoInicialObjetos = 0;
            LeanTween.scale(popUpInfoEliminar, Vector3.one * multiDelV3e, tiempoAnimacion).setOnComplete(() =>
            {
                LeanTween.scale(popUpInfoEliminar, Vector3.one * multiDelV3, tiempoAnimacion);
                popUpInfoEliminar.SetActive(false);
            });
            LeanTween.scale(popUpInfoMover, Vector3.one * multiDelV3e, tiempoAnimacion).setOnComplete(() =>
            {
                LeanTween.scale(popUpInfoMover, Vector3.one * multiDelV3, tiempoAnimacion);
                popUpInfoMover.SetActive(false);
            });
            LeanTween.scale(popUpInfoRotar, Vector3.one * multiDelV3e, tiempoAnimacion).setOnComplete(() =>
            {
                LeanTween.scale(popUpInfoRotar, Vector3.one * multiDelV3, tiempoAnimacion);
                popUpInfoRotar.SetActive(false);
            });
            LeanTween.moveLocalY(objetos, movimientoInicialObjetos, 1f).setEase(animeCurv).setOnComplete(() =>
            {
                LeanTween.moveLocalX(popUpCreacionObjetos, 1185, 1f).setEase(animeCurv).setOnComplete(() =>
                {
                    popUpCreacionObjetos.SetActive(false);
                });
                LeanTween.moveLocalY(gameObject, posicionFinal, 1f).setEase(animeCurv);
            });
            popUpMenu1 = false;
            vaAEliminar = false;
            estaRotando = false;
            vaAMover = false;
        }
        else
        {
            LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv);
        }    
    }
    public void Crear()//Botón para abrir el desplegable de la creación de objetos
    {
        popUpMenu1 = true;
        popUpCreacionObjetos.SetActive(true);
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv).setOnComplete(() => {
            movimientoInicialObjetos = 1000;
            LeanTween.moveLocalX(popUpCreacionObjetos, posicionPopUpCreaObj, 1f).setEase(animeCurv).setOnComplete(() => {
                LeanTween.moveLocalY(objetos, 1000, 1f).setEase(animeCurv);
            });
        });
    }
    public void Subir()//Botones control del scroll
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
    public void RetornadorDeBotellas()//Lista de itemes para la creación de objetos
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
    public void BotonObjeto()//Botón para crear el objeto seleccionado en el scroll. Por alguna razón hay objetos que se me crean en el vector y otros que no
    {
        objetoCreadoDeVerdad = Instantiate(ObjetoCreado[selectedItem], new Vector3(11.5f, 5f, 3.26f), Quaternion.identity);
        moviendoObjeto = true;
    }
    public void Rotacion()//Botón para rotar el objeto
    {
        popUpMenu1 = true;
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv);//Falta hacer referencia a que solo haga este movimiento el objeto que hayas clicado previamente
        popUpInfoRotar.SetActive(true);
        LeanTween.scale(popUpInfoRotar, Vector3.one * multiDelV3e, tiempoAnimacion).setOnComplete(() => {
            LeanTween.scale(popUpInfoRotar, Vector3.one * multiDelV3, tiempoAnimacion);
        });
        estaRotando = true;
    }
    public void Borrar()//Botón para Eliminar objetos
    {
        popUpMenu1 = true;
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv);
        popUpInfoEliminar.SetActive(true);
        LeanTween.scale(popUpInfoEliminar, Vector3.one * multiDelV3e, tiempoAnimacion).setOnComplete(() => {
            LeanTween.scale(popUpInfoEliminar, Vector3.one * multiDelV3, tiempoAnimacion);
        });
        vaAEliminar = true;
    }
    public void Mover()//Botón para mover un objeto
    {
        popUpMenu1 = true;
        LeanTween.moveLocalY(gameObject, 0, 1f).setEase(animeCurv);
        popUpInfoMover.SetActive(true);
        LeanTween.scale(popUpInfoMover, Vector3.one * multiDelV3e, tiempoAnimacion).setOnComplete(() => {
            LeanTween.scale(popUpInfoMover, Vector3.one * multiDelV3, tiempoAnimacion);
        });
        vaAMover = true;
    }
}
