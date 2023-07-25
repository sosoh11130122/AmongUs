using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera Cam;
    Vector3 CameraOriginalPos;
    Vector3 zvalue = new Vector3(0f, 0f, -5f);

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        CameraOriginalPos = Cam.transform.position + zvalue;
    }
    
    IEnumerator Shake(float duration, float magnitude)
    {
        float Timer = 0f;

        while (Timer <= duration)
        {
            Cam.transform.localPosition = Random.insideUnitSphere * magnitude + CameraOriginalPos;

            Timer += Time.deltaTime;

            yield return null;
        }

        Cam.transform.localPosition = CameraOriginalPos;
    }

    private void Update()
    {
        StartCoroutine(Shake(500f, 0.05f));
    }
}
