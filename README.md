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

### Be careful!

This is a development repository! Most of the above is implemented but some of it isn't!