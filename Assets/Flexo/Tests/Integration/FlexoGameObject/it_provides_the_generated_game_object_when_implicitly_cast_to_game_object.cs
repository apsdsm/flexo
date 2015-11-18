using UnityEngine;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_provides_the_generated_game_object_when_implicitly_cast_to_game_object : MonoBehaviour
    {

        FlexoGameObject flexo;

        // setup
        void Awake ()
        {
            flexo = new FlexoGameObject("FooBarBaz");
        }

        // test
        void Update ()
        {
            GameObject game_object = flexo;
            
            IntegrationTest.Assert( flexo.GameObject == game_object, "Expected the cast game object to be the same as the flexo provided game object" );
            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
        }
    }
}