# Flexo

## What is it?

I wanted a library that would allow me to quickly create new objects for my tests without having to specify them using unnatural collections of commands, sticking things together, and bolting on components. If only because it was taking way too long to write my tests when they needed specific objects.

What I wanted instead was to be able to say something like:

```
GameObject generated = Flexo
    .GameObject( "Foo" )
    .With<ComponentA>()
    .And<ComponentB>()
    .WithChild("Bar")
    .Where( "Bar" )
    .Has<ComponentC>()
    .And<ComponentD>();
```

And so I coded Flexo as my object generator.

## Intended Use

Flexo is meant to be a supplement for your testing. It helps you quickly create objects that can be used in your integration tests. I suppose it could be used in some other context, but testing is why it was originally made.

## How to use it

First of all, download the library and put the `Flexo` directory somewhere in your assets folder (I recommend keeping all your 3rd party libs in `vender` but you can put it wherever you want).

Next, make sure you're using the `Flexo` namespace in your source.

Finally, create your object using Flexo's collection of generation methods. Flexo will return a game object when it's done generating, so you can implicitly cast the new object to a declared `GameObject`.

Flexo is a tool that provides greater returns the more complex your use case. If you just want to make a game object, then it's not that much more expensive than just calling `new GameObject` but you incur a few casts and references being bounced around.

For more complex use cases, like objects with multiple children where each child has different components and you want references to those components, you can save significantly on your typing by using Flexo.

## Examples

Here are a few examples of what you can do with Flexo:

### Create a simple named object

Simple objects don't get much returns from using Flexo.

```
GameObject foo = new FlexoGameObject( "Foo" );
```

is equivalent to:

```
GameObject foo = new GameObject( "Foo" );
```

### Create an object with a previously defined parent

You can parent a flexo object to a previously created game object.

```
GameObject foo = new FlexoGameObject( "Foo" );

GameObject bar = new FlexoGameObject( "Bar" ).WithParent( parent );
```

is equivalent to:

```
GameObject parent = new GameObject( "Parent" );

GameObejct child = new GameObejct( "Child" );

child.transform.parent = parent.transform;

```

### Crete an object with components

You can tell Flexo to add components to your game objects while they're being created (you can add either your own Monobehaviours or built in components like Unity's `RigidBody`).

```
GameObject foo = new FlexoGameObject( "Foo" )
                     .With<ComponentA>()
                     .And<ComponentB>();
```

is equivalent to:

```
GameObject foo = new GameObject( "Foo" );

foo.AddComponent<ComponentA>;
foo.AddComponent<ComponentB>;
```

### Get back references to the components you just added

If you want to get a reference to the components you added, you can ask for them while constructing the object.

```
ComponentA componentA;
ComponentB componentB;

GameObject foo = new FlexoGameObject( "Foo" )
                     .With<ComponentA>( out componentA )
                     .And<ComponentB>( out componentB );
```

is equivalent to:

```
GameObject foo = new GameObject( "Foo" );

foo.AddComponent<ComponentA>;
foo.AddComponent<ComponentB>;

ComponentA componentA = foo.getComponent<ComponentA>;
ComponentB componentB = foo.getComponent<ComponentB>;
```

### Create an object with multiple children

```
GameObject foo = new FlexoGameObject( "Foo" ).WithChildren( "Bar", "Baz" );
```

is equivalent to:

```
GameObject foo = new GameObject( "Foo" );
GameObject bar = new GameObejct( "Bar" );
GameObject baz = new GameObejct( "Baz" );

bar.transform.parent = foo.transform;
baz.transform.parent = baz.transform;
```

### Create an object with multiple children, where children have components, and get references to those components

```
ComponentA componentA;
ComponentB componentB;
ComponentC componentC;

GameObject object = Flexo.GameObject( "Foo" )
                         .WithChildren( "Bar", "Baz" )
                         .Where( "Bar" )
                         .Has<ComponentA>( out componentA )
                         .And<ComponentB>( out componentB )
                         .Where( "Baz" )
                         .Has<ComponentC>( out componentC );
```

is equivalent to:

```
GameObject foo = new GameObject( "Foo" );
GameObject bar = new GameObejct( "Bar" );
GameObject baz = new GameObejct( "Baz" );

bar.transform.parent = foo.transform;
baz.transform.parent = baz.transform;

bar.addComponent<ComponentA>();
bar.addComponent<ComponentB>();

ComponentA componentA = bar.getComponent<ComponentA>();
ComponentB componentB = bar.getComponent<ComponentB>();

baz.addComponent<ComponentC>();

ComponentC componentC = baz.getComponent<ComponentC>();
```

### Write an object to the file system as a prefab

You can also write any game object you create to the file system as a prefab, but remember that its your own responsibility to create a valid path and to destroy the prefab when it isn't needed any more. This can be useful when you want to test what happens when an object is created with all its children already attached, or if you just want to make prefabs.

```
GameObject prefab = Flexo.GameObject( "Foo" )
                         .With<ComponentA>()
                         .AsPrefab( @"Assets/Foo/Bar/Baz.prefab" );
```