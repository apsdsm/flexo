using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_set_the_game_object_parent : MonoBehaviour
    {

        GameObject game_object;
        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            game_object = new GameObject( "FooBarBaz" );
            
            flexo = new FlexoGameObject().WithParent( game_object );
        }

        // test
        void Update ()
        {
            IntegrationTest.Assert( flexo.GameObject.transform.parent.gameObject.name == "FooBarBaz", "Expected parent to be 'FooBarBaz, but found: " + flexo.GameObject.transform.parent );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}