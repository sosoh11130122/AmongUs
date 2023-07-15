using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBody : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> m_Steams = new List<GameObject>();

    [SerializeField]
    public List<SpriteRenderer> m_Sparks = new List<SpriteRenderer>();

    [SerializeField]
    public List<Sprite> m_SparkSprites = new List<Sprite>();

    private int m_NowIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var Steam in m_Steams)
        {
            StartCoroutine(RandomSteam(Steam));
        }

        StartCoroutine(SparkEngine());
    }

    private IEnumerator RandomSteam(GameObject Steam)
    {
        while(true)
        {
            float Timer = Random.Range(0.5f, 1.5f);

            while(Timer >= 0f)
            {
                yield return null;

                Timer -= Time.deltaTime;
            }

            Steam.SetActive(true);

            Timer = 0f;

            while(Timer <= 0.6f)
            {
                yield return null;

                Timer += Time.deltaTime;
            }

            Steam.SetActive(false);
        }
    }

    private IEnumerator SparkEngine()
    {
        WaitForSeconds Wait = new WaitForSeconds(0.05f);

        while(true)
        {
            float Timer = Random.Range(0.2f, 1.5f);

            while(Timer >= 0f)
            {
                yield return null;

                Timer -= Time.deltaTime;
            }

            int[] Indices = new int[Random.Range(2, 7)];

            for (int i = 0; i < Indices.Length; ++i)
            {
                Indices[i] = Random.Range(0, m_SparkSprites.Count);
            }

            for (int i = 0; i < Indices.Length; ++i)
            {
                yield return Wait;

                m_Sparks[m_NowIndex].sprite = m_SparkSprites[Indices[i]];
            }

            m_Sparks[m_NowIndex++].sprite = null;

            if (m_NowIndex >= m_Sparks.Count)
            {
                m_NowIndex = 0;
            }
        }
    }
}
