using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_add_multiple_child_game_objects_to_the_generated_game_object_at_once : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject( "Foo" ).WithChildren( "Bar", "Baz", "Boz" );
        }

        // test
        void Update ()
        {
            int childCount = flexo.GameObject.transform.childCount;

            IntegrationTest.Assert( childCount == 3, "Expected exactly 3 children, but found: " + childCount.ToString() );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}