using UnityEngine;

namespace Amatsubame.Container
{
    public interface IObjectContainer
    {
        /// <summary>
        /// 渡されたゲームオブジェクトをプールに登録する
        /// </summary>
        /// <param name="original">プールにしたいオブジェクト</param>
        public void RegisterFromGameObject(GameObject original)
        {

        }

        /// <summary>
        /// 渡されたコンポーネントをプールに登録する
        /// </summary>
        /// <param name="original">プールにしたいオブジェクト</param>
        public void RegisterFromComponent<T>(T original) where T : Component
        {

        }

        /// <summary>
        /// 指定したゲームオブジェクトを取得する
        /// </summary>
        /// <param name="original">取得したいゲームオブジェクト</param>
        /// <returns>インスタンスが入ったハンドル</returns>
        public ObjectHandle<GameObject> Get(GameObject original)
        {
            return null;
        }
        /// <summary>
        /// 指定したゲームオブジェクトを取得する
        /// </summary>
        /// <param name="original">取得したいゲームオブジェクト</param>
        /// <param name="parent">親にしたいオブジェクト</param>
        /// <returns>インスタンスが入ったハンドル</returns>
        public ObjectHandle<GameObject> Get(GameObject original, Transform parent)
        {
            return null;
        }
        /// <summary>
        /// 指定したゲームオブジェクトを取得する
        /// </summary>
        /// <param name="original">取得したいゲームオブジェクト</param>
        /// <returns>インスタンスが入ったハンドル</returns>
        public ObjectHandle<GameObject> Get(GameObject original, Vector3 position, Quaternion rotation)
        {
            return null;
        }
        /// <summary>
        /// 指定したゲームオブジェクトを取得する
        /// </summary>
        /// <param name="original">取得したいゲームオブジェクト</param>
        /// <param name="parent">親にしたいオブジェクト</param>
        /// <returns>インスタンスが入ったハンドル</returns>
        public ObjectHandle<GameObject> Get(GameObject original, Vector3 position, Quaternion rotation, Transform parent)
        {
            return null;
        }

        /// <summary>
        /// 指定したコンポーネントを取得する
        /// </summary>
        /// <param name="original">取得したいコンポーネント</param>
        /// <returns>インスタンスが入ったハンドル</returns>
        public ObjectHandle<T> Get<T>(T original) where T : Component
        {
            return null;
        }
        /// <summary>
        /// 指定したコンポーネントを取得する
        /// </summary>
        /// <param name="original">取得したいコンポーネント</param>
        /// <param name="parent">親にしたいオブジェクト</param>
        /// <returns>インスタンスが入ったハンドル</returns>
        public ObjectHandle<T> Get<T>(T original, Transform parent) where T : Component
        {
            return null;
        }
        /// <summary>
        /// 指定したコンポーネントを取得する
        /// </summary>
        /// <param name="original">取得したいコンポーネント</param>
        /// <returns>インスタンスが入ったハンドル</returns>
        public ObjectHandle<T> Get<T>(T original, Vector3 position, Quaternion rotation) where T : Component
        {
            return null;
        }
        /// <summary>
        /// 指定したコンポーネントを取得する
        /// </summary>
        /// <param name="original">取得したいコンポーネント</param>
        /// <param name="parent">親にしたいオブジェクト</param>
        /// <returns>インスタンスが入ったハンドル</returns>
        public ObjectHandle<T> Get<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Component
        {
            return null;
        }
    }
}