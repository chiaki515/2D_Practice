using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{


    GameObject clickedGameObject;
    Animator animator;
    public bool Jump;
    public GameObject player;//Findより軽いから
    public Vector2 velocity; //飛ばしたい速度

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
                this.animator.SetTrigger("spring_up");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            //ジャンプ台アニメーション再生中かどうか
            bool springTrigger = stateInfo.IsName("Base Layer.Jump");

            if (Jump && springTrigger)
            {
                var relativeVelocity = velocity - collision.relativeVelocity;
                player.GetComponent<Rigidbody2D>().AddForce(transform.up * relativeVelocity, ForceMode2D.Impulse);
            }
        }
    }


}