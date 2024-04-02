Veuillez renseigner les champs suivants du projet en modifiant le csproj avec un éditeur de texte
ou en passant par par les propriétés du projet->onglet package:

-Authors
-Product
-PackageId
-Description
-PackageTags
-VersionPrefix
-RcVersionSuffix
-AlphaVersionSuffix
-PackageReleaseNotes

La configuration de publication du paquet Nuget dépend de l'environnement selectionné :

<PackageDistribution Condition=" '$(Configuration)' == 'Debug' ">-alpha.1</PackageDistribution>
<PackageDistribution Condition=" '$(Configuration)' == 'rc' ">-rc.1</PackageDistribution>
<PackageDistribution Condition=" '$(Configuration)' == 'Release' "></PackageDistribution>

-alpha: package local
-rc: package de preview
-(rien du tout): package version stable