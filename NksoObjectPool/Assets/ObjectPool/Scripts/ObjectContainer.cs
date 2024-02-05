using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

namespace Amatsubame.Container
{
    public class ObjectContainer : MonoBehaviour, IObjectContainer
    {
        // インスタンスIDをキーにする
        private Dictionary<int, ObjectPool<GameObject>> gameObjectPool = new();
        private Dictionary<int, ObjectPool<Component>> componentPool = new();

        public void RegisterFromGameObject(GameObject original)
        {
            // 登録済みならスキップ
            if (gameObjectPool.ContainsKey(original.GetInstanceID())) return;

            ObjectPool<GameObject> objectPool = new ObjectPool<GameObject>(
                         createFunc: () => Instantiate(original.gameObject),
                         actionOnGet: target => target.gameObject.SetActive(true),
                         actionOnRelease: target =>
                         {
                             target.transform.SetParent(transform);
                             target.gameObject.SetActive(false);
                         },
                         actionOnDestroy: Destroy,
                         collectionCheck: true,
                         maxSize: 100);

            gameObjectPool.Add(original.GetInstanceID(), objectPool);
        }

        public void RegisterFrom<T>(T original) where T : Component
        {
            T prefab = original;
            // 登録済みならスキップ
            if (componentPool.ContainsKey(prefab.GetInstanceID())) return;

            ObjectPool<Component> objectPool = new ObjectPool<Component>(
                     createFunc: () => Instantiate(prefab),
                         actionOnGet: target => target.gameObject.SetActive(true),
                         actionOnRelease: target =>
                         {
                             target.transform.SetParent(transform);
                             target.gameObject.SetActive(false);
                         },
                         actionOnDestroy: Destroy,
                         collectionCheck: true,
                         maxSize: 100);

            componentPool.Add(prefab.GetInstanceID(), objectPool);
        }


        public ObjectHandle<GameObject> Get(GameObject original)
        {
            GameObject instance;
            ObjectPool<GameObject> pool;

            bool isRegistered =
                gameObjectPool.TryGetValue(original.GetInstanceID(), out pool);

            if (!isRegistered)
            {
                // 辞書に登録されてない時の処理
                Debug.LogWarning($"未登録のオブジェクトだよ！→{original.name}", original);
                instance = Instantiate(original);
                return new GameObjectHandle(instance, Destroy);
            }

            // インスタンスを取得
            instance = pool.Get();

            return new GameObjectHandle(instance, pool.Release);
        }
        public ObjectHandle<GameObject> Get(GameObject original, Transform parent)
        {
            ObjectHandle<GameObject> handle = Get(original);
            handle.instance.transform.SetParent(parent);
            return handle;

        }
        public ObjectHandle<GameObject> Get(GameObject original, Vector3 position, Quaternion rotation)
        {
            ObjectHandle<GameObject> handle = Get(original);
            handle.instance.transform.position = position;
            handle.instance.transform.rotation = rotation;
            return handle;
        }
        public ObjectHandle<GameObject> Get(GameObject original, Vector3 position, Quaternion rotation, Transform parent)
        {
            ObjectHandle<GameObject> handle = Get(original);
            handle.instance.transform.position = position;
            handle.instance.transform.rotation = rotation;
            handle.instance.transform.SetParent(parent);
            return handle;
        }

        public ObjectHandle<T> Get<T>(T original) where T : Component
        {
            T instance;
            ObjectPool<Component> pool;

            bool isRegistered =
                componentPool.TryGetValue(original.GetInstanceID(), out pool);

            if (!isRegistered)
            {
                // 辞書に登録されてない時の処理
                Debug.LogWarning($"未登録のオブジェクトだよ！→{original.name}", original);

                instance = Instantiate(original);
                return new ComponentHandle<T>(instance, o => Destroy(o.gameObject));
            }

            // インスタンスを取得
            instance = pool.Get() as T;
            return new ComponentHandle<T>(instance, pool.Release);
        }
        public ObjectHandle<T> Get<T>(T original, Transform parent) where T : Component
        {
            ObjectHandle<T> handle = Get(original);
            handle.instance.transform.SetParent(parent);
            return handle;
        }
        public ObjectHandle<T> Get<T>(T original, Vector3 position, Quaternion rotation) where T : Component
        {
            ObjectHandle<T> handle = Get(original);
            handle.instance.transform.position = position;
            handle.instance.transform.rotation = rotation;
            return handle;
        }

        public ObjectHandle<T> Get<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Component
        {
            ObjectHandle<T> handle = Get(original);
            handle.instance.transform.position = position;
            handle.instance.transform.rotation = rotation;
            handle.instance.transform.SetParent(parent);
            return handle;
        }
    }
}