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

Here are some examples until I get more docs up:

### Simple object with name

```
GameObject object = Flexo.GameObject( "Foo" );
```

### Simple object with previously defined parent

```
GameObject parent = new GameObject();

GameObject object = Flexo.GameObject( "Foo" )
                         .WithParent( parent );
```

### Object with components (MonoBehaviours)

```
GameObject object = Flexo.GameObject( "Foo" )
                         .With<ComponentA>()
                         .And<ComponentB>();
```

### Object with children

```
GameObject object = Flexo.GameObject( "Foo" )
                         .WithChild( "Bar" )
                         .WithChild( "Baz" );
```

### Object with children, where children have components

```
GameObject object = Flexo.GameObject( "Foo" )
                         .WithChild( "Bar" )
                         .WithChild( "Baz" )
                         .Where( "Bar" )
                         .Has<ComponentA>()
                         .And<ComponentB>()
                         .Where( "Baz" )
                         .Has<ComponentC>();
```

### Object written to disk as a prefab

```
GameObject prefab = Flexo.GameObject( "Foo" )
                         .With<ComponentA>()
                         .AsPrefab( @"Assets/Foo/Bar/Baz.prefab" );
```