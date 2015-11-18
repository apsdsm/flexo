using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_provides_a_reference_to_the_game_object_currently_being_generated : MonoBehaviour
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
            GameObject focused = flexo.FocusedGameObject;

            IntegrationTest.Assert( focused.name == "Foo", "Expected to find object with name 'Foo' but found nothing" );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}