using UnityEngine;
using System;

using Flexo.Exceptions;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_throws_a_child_not_found_exception_if_focus_is_shifted_to_child_that_doesnt_exist : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {   
        }

        // test
        void Update ()
        {
            try
            {
                flexo = new FlexoGameObject().Where( "Baz" );
            }

            catch ( ChildNotFoundException e )
            {
               IntegrationTest.Pass();
               return;
            }
            
            catch ( Exception e )
            {
                IntegrationTest.Fail( "expected exception to be 'ChildNotFoundException' but encountered " + e.GetType().ToString() );
                return;
            }

            IntegrationTest.Fail( "expected exception to be 'ChildNotFoundException' but no exception was thrown" );
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}