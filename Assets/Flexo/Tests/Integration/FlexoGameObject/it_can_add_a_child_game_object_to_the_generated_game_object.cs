using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_add_a_child_game_object_to_the_generated_game_object : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject( "Foo" ).WithChild( "Bar" );
        }

        // test
        void Update ()
        {
            GameObject child = flexo.GameObject.transform.Find( "Bar" ).gameObject;

            IntegrationTest.Assert( child != null, "Expected to find child, but found nothing" );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}