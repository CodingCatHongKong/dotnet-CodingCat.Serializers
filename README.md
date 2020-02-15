# CodingCat.Serializers

Provides interfaces and serializers to convert between different types

#### Using the `StringSerializer`

There are some products accept only the `byte[]` such as `RabbitMq` as an input, however, it is quite annoying to convert a concrete type between `byte[]` no matter using dotnet `BinarySerializer` or `Json.Net` to convert an instance to JSON string then to `byte[]`.

`CodingCat.Serializers.Impls.StringSerializer` is implementing the `ISerializer<string>` and will be served as the default serializer for the others, thus converting anything to bytes will be more easier.

```csharp
var serializer = new StringSerializer() // -- default using UTF8 as the encoding
  .WithEncoding(Encoding.UTF7);         // -- no need to use this function if you are happy with UTF8
var input = "TEST_SERIALIZER";
var bytes = serializer.ToBytes(input);
var output = serializer.FromBytes(output);
```

#### Using the `JsonSerializer`

With `JsonSerializer`, we could easily convert any object to `byte[]` while its uses `Json.Net` internally.

```csharp
var serializer = new JsonSerializer<UserCommand>() // -- uses CodingCat.Serializers.Impls.StringSerializer by default
  .WithSerializer(new MyAwesomeStringSerializer()) // -- the default string serializer is replacable
  .WithSettings(this.jsonSerializerSettings);      // -- could setup the Json.Net setting easily
var userService = new UserService()
  .UseInputSerializer(serializer)
  .UseOutputSerializer(new BooleanSerializer());
  
var userCommand = this.GetCreateUserCommand(user);
return userService.Send(userCommand);
```

Supporting: `T FromBytes(byte[])`, `byte[] ToBytes(T)`, `string Serialize(T)` and `T Deserialize(string)`


#### How about the `struct`?

Although the `JsonSerializer` could take care almost everything, however, in some cases we would also like to restrict the input/output into a certain type such as `int` or `bool`, thus this library also provides the below serializers for this purpose:

- BooleanSerializer
- Int16Serializer
- Int32Serializer


#### What if no serializers suit my needs?

No one could promise that all requirements in this whole world are covered by their library, so if you are having any cases that the provided serializers don't fit, you could choose to extends `ISerializer<T>` which convert `T` between `byte[]`, or extends `ISerializer<T, TOutput>` which convert `T` between `TOutput`.


#### Target Frameworks

- .Net 4.6.1
- .Net Standard 2.0