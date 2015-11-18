using UnityEngine;
using UnityEditor;
using System.IO;

using Flexo.Exceptions;

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
        /// Will provide the game object that was generated up to this point as a prefab,
        /// that is stored at the provided path. Creating the path to the prefab, and 
        /// deleting the file afterwards is your own responsibility.
        /// </summary>
        /// <param name="path">path to the prefab that will be created, including the file name</param>
        /// <returns>the game object returned by the prefab utility</returns>
        public GameObject AsPrefab ( string path )
        {
            GameObject prefab = PrefabUtility.CreatePrefab( path, gameObject, ReplacePrefabOptions.Default );

            return prefab;
        }

        /// <summary>
        /// Will name the currently focused game object.
        /// </summary>
        /// <param name="name">Name to give the game object</param>
        /// <returns>reference to self</returns>
        public FlexoGameObject Called ( string name )
        {
            focusedGameObject.name = name;

            return this;
        }

        /// <summary>
        /// Will set the parent of the root object to the provided game object.
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
            focusedGameObject.AddComponent<T>();

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
        /// Alias for <see cref="With"/> method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>reference to self</returns>
        public FlexoGameObject Has<T>() where T : MonoBehaviour
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


        /// <summary>
        /// Changes focus to the child object with the specified name. The 
        /// child can be anywhere under the root object.
        /// </summary>
        /// <param name="name">Name of child to switch to</param>
        /// <exception cref="ChildNotFoundException">thrown if provided with an invalid child name</exception>
        /// <returns>reference to self</returns>
        public FlexoGameObject Where ( string name )
        {
            try
            {
                GameObject requested = gameObject.transform.Find( name ).gameObject;
                focusedGameObject = requested;
            }
            catch ( System.NullReferenceException e )
            {
                throw new ChildNotFoundException( "Couldn't find child: " + name );
            }
          
            return this;
        }
    }
}
