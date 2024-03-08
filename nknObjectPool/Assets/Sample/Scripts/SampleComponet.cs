using System.Collections;
using UnityEngine;

namespace Sample
{
    public class SampleComponet : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer meshRenderer;

        public void ChangeColorCoroutine()
        {
            meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}