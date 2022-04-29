# TosInMemory


Pour ce tos nous allons créer un jeu de données très simple
<img width="732" alt="image" src="https://user-images.githubusercontent.com/67638928/165962051-e561deeb-0fb0-4d14-af5b-9c45a5310a82.png">


Pré-requis :

```XML
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.4" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.4" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.4">
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="6.0.4" />
```


```
dotnet ef dbcontext scaffold "Data Source=tosthomasinmemory.database.windows.net;Initial Catalog=TosInMemory;Persist Security Info=True;User ID=tosthomasuser;Password=plopAzerty@1234" Microsoft.EntityFrameworkCore.SqlServer
![image](https://user-images.githubusercontent.com/67638928/165965694-1fba5f91-da87-4139-9f38-91a27d6302b7.png)



