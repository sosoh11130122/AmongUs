using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.one * 10, new Color(1, 0, 0));

        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector3.down, LayerMask.GetMask("Vent"));

        if (Hit.collider != null)
            Debug.Log(Hit.collider.name);


        // 짧은 선
        //Debug.DrawRay(transform.position, Vector2.down, new Color(1,0,0));

        //RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector3.down, LayerMask.GetMask("Vent"));

        //if (Hit.collider != null)
        //    Debug.Log(Hit.collider.name);










        //Ray2D ray = new Ray2D(transform.position, transform.down);
        //int layerMask = 1 << LayerMask.NameToLayer("Vent");

        //RaycastHit2D HitInfo = Physics2D.Raycast(this.transform.down, this.transform.up, 10.0f, 1);// 충돌한 오브젝트 정보

        //Debug.DrawRay(transform.position, transform.forward, Color.red); // 디버깅용

        //if (HitInfo.collider != null)
        //    Debug.Log(HitInfo.transform.name);

    }
}
