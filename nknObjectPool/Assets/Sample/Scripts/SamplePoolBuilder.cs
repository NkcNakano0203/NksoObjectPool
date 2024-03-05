using nkn.Container;
using System.Collections;
using UnityEngine;

namespace Sample
{
    public class SamplePoolBuilder : MonoBehaviour, IObjectContainerBuilder
    {
        [SerializeField]
        private ObjectContainer pool;

        [SerializeField]
        GameObject[] object1;

        [SerializeField]
        SampleComponet[] sampleHoge;

        void Awake()
        {
            StartCoroutine(BuildCoroutine());
        }

        public void Build(IObjectContainer pool)
        {
            for (int i = 0; i < object1.Length; i++)
            {
                pool.RegisterFromGameObject(object1[i]);
            }

            for (int i = 0; i < sampleHoge.Length; i++)
            {
                pool.RegisterFromComponent(sampleHoge[i]);
            }
        }

        private IEnumerator BuildCoroutine()
        {
            Build(pool.GetComponent<IObjectContainer>());
            yield return null;
            Debug.Log("ÉrÉãÉhèIóπ");
        }
    }
}