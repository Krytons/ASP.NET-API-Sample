# ASP.NET REST API Sample
### Developed by:
- **Bartolomeo Caruso**

---

## 1. NuGet Packages
- **MySql.EntityFrameworkCore** 
- **MySql.Data.EntityFramework**
- **Microsoft.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.Tools**
- **Microsoft.AspNetCore.Mvc.NewtonsoftJson**
- **Newtonsoft.Json**

---

## 2. Useful commands
- **Migration**
    ```bash
        EntityFrameworkCore\Add-Migration MigrationClassName
    ```
- **Update database**
    ```bash
        EntityFrameworkCore\Update-Database
    ```

## 3. Exposed endpoints
- **[GET] localhost:5001/api/products/init** -- Used to insert 3 default product
- **[GET] localhost:5001/api/products** -- Obtain all products
- **[GET] localhost:5001/api/products/{id}** -- Obtain product by id
- **[GET] localhost:5001/api/products/filter/{query}** -- Filter products wich name contains the query
- **[POST] localhost:5001/api/products}** -- Add a new product
- **[PUT] localhost:5001/api/products/{id}** -- Modify product by id
- **[DELETE] localhost:5001/api/products/{id}** -- Delete product by id
