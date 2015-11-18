using UnityEngine;
using System.Collections;

namespace Flexo
{
    public class FlexoGameObject
    {
        // the target of all generation methods
        private GameObject gameObject;

        // the focus of current generation methods
        private GameObject focusedGameObject;

        /// <summary>
        /// Creates a new Flexo Game Object
        /// </summary>
        /// <param name="name">Name that will be passed to generated game object</param>
        public FlexoGameObject ( string name = "New Flexo Game Object" )
        {
            gameObject = new GameObject( name );
            focusedGameObject = gameObject;
        }

        /// <summary>
        /// When implicitly cast as a game object, will return the internal generated class
        /// of the Flexo Game Object.
        /// </summary>
        /// <param name="flexoGameObject">target to cast from</param>
        static public implicit operator GameObject ( FlexoGameObject flexoGameObject )
        {
            return flexoGameObject.GameObject;
        }


        /// <summary>
        /// Return the root game object being generated.
        /// </summary>
        public GameObject GameObject { get { return gameObject; } }

        /// <summary>
        /// Return the game object that is currently the focus for generator methods.
        /// </summary>
        public GameObject FocusedGameObject {  get { return focusedGameObject; } }

        /// <summary>
        /// Associates the provided parent with the generated game object.
        /// </summary>
        /// <param name="parent">GameObject that will be used as the parent</param>
        /// <returns>reference to self</returns>
        public FlexoGameObject WithParent ( GameObject parent )
        {
            gameObject.transform.parent = parent.transform;

            return this;
        }


        /// <summary>
        /// Adds the provided component type to the generated game object.
        /// </summary>
        /// <typeparam name="T">the type of component to add</typeparam>
        /// <returns>reference to self</returns>
        public FlexoGameObject With<T>() where T : MonoBehaviour
        {
            gameObject.AddComponent<T>();

            return this;
        }
        
        
        /// <summary>
        /// Alias for <see cref="With"/> method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>reference to self</returns>
        public FlexoGameObject And<T>() where T : MonoBehaviour
        {
            return With<T>();
        }


        /// <summary>
        /// Attaches a child to the generated game object.
        /// </summary>
        /// <param name="name">Name to give child object</param>
        /// <returns>reference to self</returns>
        public FlexoGameObject WithChild ( string name )
        {
            GameObject child = new GameObject( name );

            child.transform.parent = gameObject.transform;

            return this;
        }

        public FlexoGameObject Where ( string name )
        {
            GameObject requested = gameObject.transform.Find( name ).gameObject;

            focusedGameObject = requested;

            return this;
        }
    }
}
