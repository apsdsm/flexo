using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_name_the_generated_object_from_a_method : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject().Called( "FooBarBaz" );
        }

        // test
        void Update ()
        {
            string name = flexo.GameObject.name;

            IntegrationTest.Assert( name == "FooBarBaz", "Expected name to be 'FooBarBaz' but found: " + name );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}