using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_add_new_components_to_the_generated_object_using_the__with__method : MonoBehaviour
    {
        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject().With<TestComponent>();
        }

        // test
        void Update ()
        {
            TestComponent component = flexo.GameObject.GetComponent<TestComponent>();

            IntegrationTest.Assert( component != null, "expected component, but found null" );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}