using UnityEngine;
using System;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoTests" )]
    public class it_can_create_a_new_flexo_game_object : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = Flexo.GameObject();
        }

        // test
        void Update ()
        {
            Type type = flexo.GetType();

            IntegrationTest.Assert( type == typeof( FlexoGameObject ), "Expected type 'FlexoGameObject' but found: " + type.ToString() );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}