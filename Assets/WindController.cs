using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour {

    //Animator animator;
    GameObject clickedGameObject;
    public bool Wind;
    public GameObject player;//Findより軽いから
    public GameObject windObject;
    //public Vector2 velocity; //飛ばしたい速度

    void Start()
    {
        //this.animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            clickedGameObject = hit2d.transform.gameObject;

            if (hit2d && clickedGameObject.name == "Wind")
            {
                windObject.SetActive(true);
                //this.animator.SetBool("WindBool", true);
                //GetComponent<AreaEffector2D>().enabled = true;
                //Debug.Log(hit2d.transform.gameObject.name);
            } 
        }else{
            windObject.SetActive(false);
            //this.animator.SetBool("WindBool", false);
            //GetComponent<AreaEffector2D>().enabled = false;
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //送風機アニメーション再生中かどうか
    //        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    //        bool windBool = stateInfo.IsName("Base Layer.Wind");

    //        if (Wind && windBool)
    //        {
    //            GetComponent<AreaEffector2D>().enabled = true;
    //            //var relativeVelocity = velocity - collision.relativeVelocity;
    //            //player.GetComponent<Rigidbody2D>().AddForce(transform.right * velocity, ForceMode2D.Impulse);
    //        }
    //    }
    //}



}
