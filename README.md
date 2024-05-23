# Projet Informatiser une Gestion de Stock

Le projet peut être trouvé dans le dossier _Projet-Gestion de Stock_. Il s'agit d'un projet « Application Windows Form (.Net Framework) » qui été développé sur Visual Studio 2019.

Le projet utilise la librairie « System.Data.SQLite » qui peut être installée via NuGet avec la commande : 
> Install-Package System.Data.SQLite -Version 1.0.117

Pour visualiser la base de donnée, on a utilisé ‘SQLite Browser’ disponible ici https://sqlitebrowser.org/dl/, aussi bien pour Pc que pour Mac.

# Objectif 

Ce projet a pour objectif la création d’une application de gestion d’un catalogue de fournitures de bureau par l’intermédiaire d’une base de données de type SQLite à l'aide de Microsoft Visual Studio .
La base de données se trouve à « Projet-Gestion de Stock/Hector/Hector.SQLite ».
Il intègre trois fonctionnalités :
– Intégration d'un fichier « csv » pour alimenter la base de données.
– Gestion de la base de données via des écrans clairs et explicites.
– Exportation de toutes les données dans un fichier « csv » au même format que le fichier « csv » fournis pour la première demande.

# Interface

## Fenêtre Principale :
Celle-ci intègre un ListView pour afficher les éléments de la base de données. Elle permet de gérer le tri des éléments en fonctions de la colonne sélectionnée, et de gérer des groupes d'éléments pour certaines colonnes :

Si on a chargé une liste « d’Articles » :
- Si le trie est sur la colonne « description », on groupe par la première lettre.
- Si le trie est sur la colonne « familles », on groupe par famille.
- Si le trie est sur la colonne « sous-familles », on groupe par sous-famille.
- Si le trie est sur la colonne « marque », on groupe par marques.

Sinon on groupe seulement par la première lettre si le trie est sur la colonne « description .

## TreeView :
La partie droite comprend un TreeView qui permet de choisir la table dont l'on souhaite observer les éléments. Elle permet aussi de filtrer en fonction d'un élément spécifique d'une autre table (lié par clé étrangère).

## Menu Fichier :
La barre en haut de l'interface intègre un menu Fichier, celui-ci permet plusieurs actions :
- Actualiser : met à jour les éléments par rapport à ceux dans la base de données à l'instant t (à utiliser en cas d'action sur la base de données à l'extérieur de l'application).
- Importer : importe des données dans la base de données depuis un fichier .csv qui respecte le format du fichier « Projet-Gestion de Stock/Données à intégrer.csv ».
- Exporter : exporte les données de la base de données dans un fichier .csv au même format que le fichier « Projet-Gestion de Stock/Données à intégrer.csv ».

# Raccourcis :

- Les touches « Entrée » et « Espace », et double clic sur un élément du ListView sélectionné ouvre la fenêtre de modification de l’élément associé.
- La touche F5 recharge la liste des éléments, tout comme le sous-menu « Actualiser ».
- La touche « Supp » demande la suppression de l‘élément du ListView sélectionné.
- Le clic droit ouvre un menu contextuel permettant d'ajouter un élément, de modifier ou de supprimer l‘élément du ListView sélectionné (grisé si aucun élément n'est sélectionné).
