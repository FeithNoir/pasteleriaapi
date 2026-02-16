# API Endpoints Documentation 🚀

This document outlines the required endpoints for the Backend API to fully support the current and future features of **PasteleryApp**.

## Base URL
`https://api.pastelery.com/v1`

---

## 🍰 Cakes Module

### GET `/cakes`
- **Description**: Retrieves a list of all available cakes.
- **Response**: `200 OK` (Array of `Cake` objects).

### GET `/cakes/{id}`
- **Description**: Retrieves detailed information for a specific cake.
- **Response**: `200 OK` or `404 Not Found`.

---

## 📦 Inventory Module

### GET `/inventory`
- **Description**: List all ingredients and stock levels.
- **Auth Required**: Admin/Store Manager.
- **Response**: `200 OK` (Array of `Ingredient` objects).

### POST `/inventory`
- **Description**: Add a new ingredient.
- **Payload**: `Ingredient` (excluding ID).
- **Response**: `201 Created`.

### PUT `/inventory/{id}`
- **Description**: Update an existing ingredient (stock, status, expiry).
- **Response**: `200 OK`.

### DELETE `/inventory/{id}`
- **Description**: Remove an ingredient from the system.
- **Response**: `204 No Content`.

---

## 🥖 Recipes Module

### GET `/recipes`
- **Description**: Retrieve all registered recipes.
- **Response**: `200 OK`.

### GET `/recipes/{id}`
- **Description**: Detailed recipe steps and required ingredients.
- **Response**: `200 OK`.

---

## 👤 Auth & User Module

### POST `/auth/login`
- **Description**: User authentication.
- **Payload**: `{ username, password }`.
- **Response**: `200 OK` (JWT Token + User Info).

### GET `/auth/profile`
- **Description**: Get current user profile data.
- **Auth Required**: Bearer Token.
- **Response**: `200 OK`.

---

## 📄 Document Module

### GET `/documents`
- **Description**: Retrieves a list of all documents.
- **Response**: `200 OK` (Result<List<ListDocumentDto>>).

### GET `/documents/{id}`
- **Description**: Retrieves detailed information for a specific document.
- **Response**: `200 OK` (Result<DocumentDto>) or `404 Not Found`.

### POST `/documents`
- **Description**: Adds a new document.
- **Payload**: `CreateDocumentDto`.
- **Response**: `201 Created` (Result<DocumentDto>).

### PUT `/documents/{id}`
- **Description**: Updates an existing document.
- **Payload**: `DocumentDto`.
- **Response**: `200 OK` (Result<DocumentDto>) or `400 Bad Request` or `404 Not Found`.

### DELETE `/documents/{id}`
- **Description**: Deletes a document from the system.
- **Response**: `204 No Content` (Result<bool>) or `400 Bad Request` or `404 Not Found`.

---

## 🥕 Ingredient Module

### GET `/ingredients`
- **Description**: Retrieves a list of all ingredients.
- **Response**: `200 OK` (Result<List<ListIngredientDto>>).

### GET `/ingredients/{id}`
- **Description**: Retrieves detailed information for a specific ingredient.
- **Response**: `200 OK` (Result<IngredientDto>) or `404 Not Found`.

### POST `/ingredients`
- **Description**: Adds a new ingredient.
- **Payload**: `CreateIngredientDto`.
- **Response**: `201 Created` (Result<IngredientDto>).

### PUT `/ingredients/{id}`
- **Description**: Updates an existing ingredient.
- **Payload**: `IngredientDto`.
- **Response**: `200 OK` (Result<IngredientDto>) or `400 Bad Request` or `404 Not Found`.

### DELETE `/ingredients/{id}`
- **Description**: Deletes an ingredient from the system.
- **Response**: `204 No Content` (Result<bool>) or `400 Bad Request` or `404 Not Found`.

---

## 📦 Inventory Item Module

### GET `/inventoryitems`
- **Description**: Retrieves a list of all inventory items.
- **Response**: `200 OK` (Result<List<ListInventoryItemDto>>).

### GET `/inventoryitems/{id}`
- **Description**: Retrieves detailed information for a specific inventory item.
- **Response**: `200 OK` (Result<InventoryItemDto>) or `404 Not Found`.

### POST `/inventoryitems`
- **Description**: Adds a new inventory item.
- **Payload**: `CreateInventoryItemDto`.
- **Response**: `201 Created` (Result<InventoryItemDto>).

### PUT `/inventoryitems/{id}`
- **Description**: Updates an existing inventory item.
- **Payload**: `InventoryItemDto`.
- **Response**: `200 OK` (Result<InventoryItemDto>) or `400 Bad Request` or `404 Not Found`.

### DELETE `/inventoryitems/{id}`
- **Description**: Deletes an inventory item from the system.
- **Response**: `204 No Content` (Result<bool>) or `400 Bad Request` or `404 Not Found`.

---

## 🍳 Recipe Module

### GET `/recipes`
- **Description**: Retrieves a list of all recipes.
- **Response**: `200 OK` (Result<List<ListRecipeDto>>).

### GET `/recipes/{id}`
- **Description**: Retrieves detailed information for a specific recipe.
- **Response**: `200 OK` (Result<RecipeDto>) or `404 Not Found`.

### POST `/recipes`
- **Description**: Adds a new recipe.
- **Payload**: `CreateRecipeDto`.
- **Response**: `201 Created` (Result<RecipeDto>).

### PUT `/recipes/{id}`
- **Description**: Updates an existing recipe.
- **Payload**: `RecipeDto`.
- **Response**: `200 OK` (Result<RecipeDto>) or `400 Bad Request` or `404 Not Found`.

### DELETE `/recipes/{id}`
- **Description**: Deletes a recipe from the system.
- **Response**: `204 No Content` (Result<bool>) or `400 Bad Request` or `404 Not Found`.

---

## 🥣 Recipe Ingredient Module

### GET `/recipeingredients`
- **Description**: Retrieves a list of all recipe ingredients.
- **Response**: `200 OK` (Result<List<ListRecipeIngredientDto>>).

### GET `/recipeingredients/{id}`
- **Description**: Retrieves detailed information for a specific recipe ingredient.
- **Response**: `200 OK` (Result<RecipeIngredientDto>) or `404 Not Found`.

### POST `/recipeingredients`
- **Description**: Adds a new recipe ingredient.
- **Payload**: `CreateRecipeIngredientDto`.
- **Response**: `201 Created` (Result<RecipeIngredientDto>).

### PUT `/recipeingredients/{id}`
- **Description**: Updates an existing recipe ingredient.
- **Payload**: `RecipeIngredientDto`.
- **Response**: `200 OK` (Result<RecipeIngredientDto>) or `400 Bad Request` or `404 Not Found`.

### DELETE `/recipeingredients/{id}`
- **Description**: Deletes a recipe ingredient from the system.
- **Response**: `204 No Content` (Result<bool>) or `400 Bad Request` or `404 Not Found`.

---

## 💡 Future Implementation Tips
1. **CORS**: Ensure the Backend allows requests from `http://localhost:4200`.
2. **Standard Headers**: Use `Content-Type: application/json` for all requests.
3. **Error Handling**: Return consistent error objects (e.g., `{ error: "Message", code: 400 }`).

---

## TypeScript Interfaces

```typescript
export interface Result<T> {
  isSuccessful: boolean;
  data: T;
  errors: string[];
}

export interface DocumentDto {
  id: string;
  name: string;
  filePath: string;
  type: string;
  uploadDate: string; // DateTime
  uploadedByUserId: string;
}

export interface CreateDocumentDto {
  name: string;
  filePath: string;
  type: string;
  uploadedByUserId: string;
}

export interface ListDocumentDto {
  id: string;
  name: string;
  type: string;
  uploadDate: string; // DateTime
  uploadedByUserId: string;
}

export interface IngredientDto {
  id: string;
  name: string;
  description: string;
  costPerUnit: number;
  unit: string;
  supplierInfo: string;
  // Navigation properties are typically not included in DTOs for simple CRUD,
  // or are represented by their IDs or simplified DTOs to avoid circular references.
  // For simplicity, I'm omitting them here as they would require more complex DTO structures.
  // recipeIngredients: RecipeIngredient[];
  // inventoryItems: InventoryItem[];
}

export interface CreateIngredientDto {
  name: string;
  description: string;
  costPerUnit: number;
  unit: string;
  supplierInfo: string;
  // recipeIngredients: RecipeIngredient[];
  // inventoryItems: InventoryItem[];
}

export interface ListIngredientDto {
  id: string;
  name: string;
  description: string;
  costPerUnit: number;
  unit: string;
}

export interface InventoryItemDto {
  id: string;
  ingredientId: string; // Guid in C# is string in TS
  // ingredient: Ingredient; // Omitted to avoid circular reference and simplify
  currentQuantity: number;
  minimumQuantity: number;
  lastUpdated: string; // DateTime
  location: string;
}

export interface CreateInventoryItemDto {
  ingredientId: string;
  // ingredient: Ingredient; // Omitted to avoid circular reference and simplify
  currentQuantity: number;
  minimumQuantity: number;
  location: string;
}

export interface ListInventoryItemDto {
  id: string;
  ingredientId: string;
  currentQuantity: number;
  minimumQuantity: number;
  lastUpdated: string;
  location: string;
}

export interface RecipeDto {
  id: string;
  name: string;
  description: string;
  instructions: string;
  totalCost: number;
  suggestedPrice: number;
  imageUrl: string;
  // recipeIngredients: RecipeIngredient[]; // Omitted to avoid circular reference and simplify
}

export interface CreateRecipeDto {
  name: string;
  description: string;
  instructions: string;
  suggestedPrice: number;
  imageUrl: string;
  // recipeIngredients: RecipeIngredient[]; // Omitted to avoid circular reference and simplify
}

export interface ListRecipeDto {
  id: string;
  name: string;
  description: string;
  totalCost: number;
  suggestedPrice: number;
}

export interface RecipeIngredientDto {
  id: string;
  recipeId: string;
  // recipe: Recipe; // Omitted to avoid circular reference and simplify
  ingredientId: string;
  // ingredient: Ingredient; // Omitted to avoid circular reference and simplify
  quantity: number;
  unit: string;
}

export interface CreateRecipeIngredientDto {
  recipeId: string;
  // recipe: Recipe; // Omitted to avoid circular reference and simplify
  ingredientId: string;
  // ingredient: Ingredient; // Omitted to avoid circular reference and simplify
  quantity: number;
  unit: string;
}

export interface ListRecipeIngredientDto {
  id: string;
  recipeId: string;
  // recipe: Recipe; // Omitted to avoid circular reference and simplify
  ingredientId: string;
  // ingredient: Ingredient; // Omitted to avoid circular reference and simplify
  quantity: number;
  unit: string;
}
```