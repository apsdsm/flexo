using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_can_add_built_in_components_to_generated_object_using_the__has__method : MonoBehaviour
    {

        GameObject game_object;
        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject().Has<Rigidbody>();
        }

        // test
        void Update ()
        {
            Rigidbody rigidbody = flexo.GameObject.GetComponent<Rigidbody>();

            IntegrationTest.Assert( rigidbody != null, "expected component, but found null" );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}