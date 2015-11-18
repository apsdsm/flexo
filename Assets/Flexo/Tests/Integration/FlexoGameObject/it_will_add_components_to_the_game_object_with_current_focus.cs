using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_will_add_components_to_the_game_object_with_current_focus : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject( "Foo" ).WithChild( "Bar" ).Where( "Bar" ).Has<TestComponent>();
        }

        // test
        void Update ()
        {
            GameObject child = flexo.GameObject.transform.Find( "Bar" ).gameObject;
            TestComponent component = child.GetComponent<TestComponent>();

            IntegrationTest.Assert( component != null, "Expected to find component on child, but found nothing" );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}