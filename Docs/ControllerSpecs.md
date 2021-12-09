# Api specifications

## Http status codes and return types

###  Get One
 - 200 Ok - Returns the entity
 - 404 NotFound - Entity not found

### Get All
- 200 Ok - Retuns a list of entities

### Create
- 201 Created - returns the new created entity
- 400 BadRequest - ModelsState invalid

### Update
- 204 NoContent - Updated
- 404 NotFound - no entity to update
- 400 BadRequest - ModelsState invalid

### Delete
- 404 NotFound - Not entity to delete
- 204 NoContet - Deleted
