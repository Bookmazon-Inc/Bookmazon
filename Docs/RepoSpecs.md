# Repo specifications

## Generally
> all repo methods can/schould throw ``ArgumentNullException``  
> > An ArgumentNullException exception is thrown when a method is invoked   and at least one of the passed arguments is null but should never be null.
> #


## Return types

## Get
> Methods Which return one entity by a unique key  
> If no entity was found return null
 ```csharp 
 Task<Entity?> MethodName(key(s));
 ```


## List
> Methods Which return a list of entities  
> If no entity was found return emty list
```csharp 
Task<IEnumerable<Entity>> MethodName();
```

## Add
> Methods for adding one or more entities to the database
```csharp 
void MethodName(Entity entity);
```

## Update
> Methods for updating one or more entities in the database
```csharp 
void MethodName(Entity entity);
```

## Delete
> Methods for deleting one or more entities in the database
```csharp 
void Delete(Entity entity);
```
