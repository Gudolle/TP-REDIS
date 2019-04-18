# TP DE PROGRAMMATION REDIS
De Gudolle Antoine et Giorgi Sébastien

#### Architecture de l'application
---
L'application est réalisée sous ASP .Net MVC. Nous avons intégré un module Swagger, qui permet de visualiser les requêtes HTTP disponibles de notre API.


### Description de l'API
---

L'API est capable d'envoyer une note, elle peut aussi récupérer une note, ou toutes les notes.
Il est également possible de supprimer une note.
Pour chaque requête exécutée, l'application va se connecter avec Redis qui fonctionne avec Docker.


### Lancement de l'application
---

Lorsqu'on lance l'application, on peut accèder à la documentation de l'api à cette adresse: <http://localhost:58883/swagger>

On accède donc à toutes les requêtes HTTP disponibles :

* Ajouter une note :
>POST http://localhost:58883/Note avec comme donnée : "Note" = Contenue et "Auteur" = Nom de l'auteur
>Retourne l'identifiant GUID de la note nouvellement crée

* Lire toutes les notes :
>GET http://localhost:58883/Note
>Retourne une listes des notes existant avec l'identifiant et le contenue de la note (Contenue, Auteur, et date de création)

* Lire une seules note :
>GET http//localhost:58883/Note/{Identifiant} (Remplacer **{identifiant}** par l'identifiant de la note que on souhaite voir)
>Retourne la note si elle existe ou sinon retourne l'identifiant et avec une value null

* Supprimer une note :
>DELETE http://localhost:58883/Note/{Identifiant} (Remplacer **{identifiant}** par l'identifiant de la note que on souhaite supprimer)
>Retourne un booléen si sa a bien était supprimer

Les réponses sont au format JSON par défaut, mais on peut changer le format en XML, HTML....


### Description du code :
----

Le code se sépare en plusieurs fichiers :
* Controller/NoteController.cs
>S'occupe de la partie HTTP et redirige aprés dans les bonnes méthodes correspondante

* Models/RedisConnect.cs
>S'occupe de toute la partie en communication directe avec REDIS

* Models/Note.cs
>Class qui correspond a une note

* Models/Data
>Retranscription des data de REDIS en Key/Value (Value était un objet de type Note)