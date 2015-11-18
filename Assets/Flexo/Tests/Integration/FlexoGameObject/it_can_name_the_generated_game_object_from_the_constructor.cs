using UnityEngine;
using System;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_name_the_generated_game_object_from_the_constructor : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject("FooBarBaz");
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