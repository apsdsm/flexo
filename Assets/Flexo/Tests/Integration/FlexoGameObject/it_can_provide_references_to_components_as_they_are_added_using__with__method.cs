﻿using UnityEngine;

namespace Flexo.Test
{
    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_provide_references_to_components_as_they_are_added_using__with__method : MonoBehaviour
    {

        FlexoGameObject flexo;
        TestComponent component;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject( "Foo" ).With<TestComponent>( out component );
        }

        // test
        void Update ()
        {
            GameObject focused = flexo.FocusedGameObject;

            IntegrationTest.Assert( component != null, "Expected component to reference a component, it was null" );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}