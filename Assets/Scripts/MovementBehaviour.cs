using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] PopUps popUps;
   
    // Start is called before the first frame update
    void Start()
    {
        moviendoobjeto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moviendoObjeto == true && objetoCreadoDeVerdad != null)
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
        }
    }
}
