using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{

    Animator animator;
    GameObject clickedGameObject;
    public bool Magnet;
    public GameObject player;//Findより軽いから
    public GameObject magnetObject;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            clickedGameObject = hit2d.transform.gameObject;

            if (hit2d && clickedGameObject.name == "Magnet")
            {
                magnetObject.SetActive(true);
                this.animator.SetBool("WindBool", true);
                GetComponent<AreaEffector2D>().enabled = true;
                //Debug.Log(hit2d.transform.gameObject.name);
            }
        }
        else
        {
            magnetObject.SetActive(false);
            this.animator.SetBool("WindBool", false);
            GetComponent<AreaEffector2D>().enabled = false;
        }
    }


}

