using UnityEngine;
using System;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_provides_a_generated_game_object : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject();
        }

        // test
        void Update ()
        {
            Type type = flexo.GameObject.GetType();

            IntegrationTest.Assert( type == typeof( GameObject ), "Expected type 'GameObject' but found: " + type.ToString() );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}