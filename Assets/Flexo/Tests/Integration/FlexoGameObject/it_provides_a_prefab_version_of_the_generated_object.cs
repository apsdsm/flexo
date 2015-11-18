using UnityEngine;
using System.IO;

namespace Flexo.Test
{

    [IntegrationTest.DynamicTest( "Flexo.FlexoGameObjectTests" )]
    public class it_provides_a_prefab_version_of_the_generated_object : MonoBehaviour
    {

        GameObject prefab;

        // setup
        void Awake ()
        {
            Directory.CreateDirectory( @"Assets/__FlexoTests" );

            prefab = new FlexoGameObject( "Foo" ).AsPrefab( @"Assets/__FlexoTests/foo.prefab" );
        }

        // test
        void Update ()
        { 
            bool exists = File.Exists( @"Assets/__FlexoTests/foo.prefab" );

            IntegrationTest.Assert( exists, "expected a prefab file at the specified location, but found nothing" );

            IntegrationTest.Assert( prefab != null, "expected a reference to a game object, but found nothing" );

            IntegrationTest.Pass();
        }

        // teardown
        void OnDisable ()
        {
            Directory.Delete( @"Assets/__FlexoTests", true );
            File.Delete( @"Assets/__FlexoTests.meta" );
        }
    }
}