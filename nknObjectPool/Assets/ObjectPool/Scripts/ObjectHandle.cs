using System;
using UnityEngine;

namespace Nkso.Container
{
    public abstract class ObjectHandle<T> : IDisposable
    {
        public readonly T instance;

        public ObjectHandle(T instance)
        {
            this.instance = instance;
        }

        /// <summary>
        /// 使い終わった時の処理
        /// </summary>
        public abstract void Dispose();
    }

    public class GameObjectHandle : ObjectHandle<GameObject>
    {
        Action<GameObject> onDispose;

        public GameObjectHandle(GameObject instance, Action<GameObject> onDispose) : base(instance)
        {
            this.onDispose = onDispose;
        }

        public override void Dispose()
        {
            onDispose.Invoke(instance);
        }
    }

    public class ComponentHandle<T> : ObjectHandle<T> where T : Component
    {
        Action<T> onDispose;

        public ComponentHandle(T instance, Action<T> onDispose) : base(instance)
        {
            this.onDispose = onDispose;
        }

        public override void Dispose()
        {
            onDispose.Invoke(instance);
        }
    }
}