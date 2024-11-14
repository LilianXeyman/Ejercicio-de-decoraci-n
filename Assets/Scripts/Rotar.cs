using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Rotación()
    {
        LeanTween.moveLocalY(popUpMenu, 0, 1f).setEase(animeCurv);//Falta hacer referencia a que solo haga este movimiento el objeto que hayas clicado previamente
        popUpComoSeUsa.SetActive(true);
        LeanTween.scale(popUpComoSeUsa, Vector3.one*multiDelV3e, tiempoAnimacion).setOnComplete(() => {
            LeanTween.scale(popUpComoSeUsa, Vector3.one * multiDelV3, tiempoAnimacion);
        }); 
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(1, 0, 0);
        }
    }
}
