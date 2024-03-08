using nkn.Container;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{

    public class SampleCreator : MonoBehaviour
    {
        [SerializeField]
        ObjectContainer objectContainer;

        [SerializeField]
        float createObjSpan = 0.5f;

        [SerializeField]
        GameObject[] createObjectPrefabs;


        void Start()
        {
            StartCoroutine(CreateObjectCoroutine(createObjSpan));
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
    }
}