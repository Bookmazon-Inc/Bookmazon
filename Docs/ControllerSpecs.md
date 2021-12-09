# Api specifications

## Http status codes and return types

###  Get One ``[Httpget] - /{id}``
 - 200 Ok - Returns the entity
 - 404 NotFound - Entity not found

### Get All ``[HttpGet] - /``
- 200 Ok - Retuns a list of entities

### Create ``[HttpPost] - /``
- 201 Created - returns the new created entity
- 400 BadRequest - ModelsState invalid

### Update ``[HttpPut] - /{id}``
- 204 NoContent - Updated
- 404 NotFound - no entity to update
- 400 BadRequest - ModelsState invalid

### Delete ``[HttpDelete] - /{id}``
- 404 NotFound - Not entity to delete
- 204 NoContet - Deleted
