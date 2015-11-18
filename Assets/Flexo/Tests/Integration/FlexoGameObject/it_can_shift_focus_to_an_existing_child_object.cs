using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_shift_focus_to_an_existing_child_object : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject( "Foo" );
        }

        // test
        void Update ()
        {

            flexo = new FlexoGameObject( "Foo" ).WithChild( "Bar" ).Where( "Bar" );

            GameObject focused = flexo.FocusedGameObject;

            IntegrationTest.Assert( focused.name == "Bar", "'Where' method should shift focus to 'Bar' object, but found:" + focused.ToString() );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}