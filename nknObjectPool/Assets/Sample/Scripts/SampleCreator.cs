using nkn.Container;
using Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCreator : MonoBehaviour
{
    [SerializeField]
    float createObjSpan = 0.5f;

    [SerializeField]
    float createComponentSpan = 0.8f;

    [SerializeField]
    GameObject[] createObjectPrefabs;

    [SerializeField]
    SampleComponet sampleComponetPrefab;

    [SerializeField]
    ObjectContainer objectContainer;

    void Start()
    {
        StartCoroutine(CreateObjectCoroutine(createObjSpan));
        StartCoroutine(CreateComponetCoroutine(createComponentSpan));
    }

    IEnumerator CreateObjectCoroutine(float timeSpan)
    {
        int i = 0;
        List<ObjectHandle<GameObject>> handles = new(5);

        while (true)
        {
            int randomInsCount = Random.Range(1, 5);

            for (int j = 0; j < randomInsCount; j++)
            {
                var handle = objectContainer.Get(createObjectPrefabs[i], transform);
                handles.Add(handle);

                Vector3 randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
                handle.instance.transform.position = randomPos;
            }

            yield return new WaitForSeconds(timeSpan);

            foreach (var handle in handles)
            {
                handle.Dispose();
            }

            handles.Clear();

            i = i + 1 >= createObjectPrefabs.Length ? 0 : i + 1;
        }
    }

    IEnumerator CreateComponetCoroutine(float timeSpan)
    {
        List<ObjectHandle<SampleComponet>> handles = new(5);

        while (true)
        {
            int randomInsCount = Random.Range(1, 5);

            for (int j = 0; j < randomInsCount; j++)
            {
                var handle = objectContainer.Get(sampleComponetPrefab, transform);
                handles.Add(handle);

                handle.instance.ChangeColorCoroutine();

                Vector3 randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
                handle.instance.transform.position = randomPos;
            }

            yield return new WaitForSeconds(timeSpan);

            foreach (var handle in handles)
            {
                handle.instance.ChangeColorCoroutine();
                handle.Dispose();
            }

            handles.Clear();
        }
    }
}