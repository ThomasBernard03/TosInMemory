# TosInMemory


Pour ce tos nous allons créer un jeu de données très simple
<img width="732" alt="image" src="https://user-images.githubusercontent.com/67638928/165962051-e561deeb-0fb0-4d14-af5b-9c45a5310a82.png">


Pré-requis :

On ajoute ces différents packages à notre projet

```XML
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.4" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.4" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.4">
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="6.0.4" />
```

On peut alors saisir cette commande afin de générer nos classes en fonction de notre schéma de base de données
```
dotnet ef dbcontext scaffold "Data Source=databaseserveraddress;Initial Catalog=TosInMemory;Persist Security Info=True;User ID=username;Password=password" Microsoft.EntityFrameworkCore.SqlServer
```

<img width="212" alt="image" src="https://user-images.githubusercontent.com/67638928/165966573-a6091e76-2df5-4108-8b20-5fe3468cbc3d.png">

Nos entitées sont alors générées

```C#
public class ClubService
{
	private readonly TosInMemoryContext _tosInMemoryContext;

	public ClubService()
	{
		_tosInMemoryContext = new();
	}

	/// <summary>
        /// This method generate a random number of clubs
        /// </summary>
		public void GenerateClubs()
        {
        }
}
````
On peut alors créé des jeux d'essais sur lequls nous pourront réaliser nos tests afin de valider nos modèles


  


