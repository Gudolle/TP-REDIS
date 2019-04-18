# TP DE PROGRAMMATION REDIS
De Gudolle Antoine et Giorgi S�bastien

#### Architecture de l'application
---
L'application est r�alis�e sous ASP .Net MVC. Nous avons int�gr� un module Swagger, qui permet de visualiser les requ�tes HTTP disponibles de notre API.


### Description de l'API
---

L'API est capable d'envoyer une note, elle peut aussi r�cup�rer une note, ou toutes les notes.
Il est �galement possible de supprimer une note.
Pour chaque requ�te ex�cut�e, l'application va se connecter avec Redis qui fonctionne avec Docker.


### Lancement de l'application
---

Lorsqu'on lance l'application, on peut acc�der � la documentation de l'api � cette adresse: <http://localhost:58883/swagger>

On acc�de donc � toutes les requ�tes HTTP disponibles :

* Ajouter une note :
>POST http://localhost:58883/Note avec comme donn�e : "Note" = Contenue et "Auteur" = Nom de l'auteur
>Retourne l'identifiant GUID de la note nouvellement cr�e

* Lire toutes les notes :
>GET http://localhost:58883/Note
>Retourne une listes des notes existant avec l'identifiant et le contenue de la note (Contenue, Auteur, et date de cr�ation)

* Lire une seules note :
>GET http//localhost:58883/Note/{Identifiant} (Remplacer **{identifiant}** par l'identifiant de la note que on souhaite voir)
>Retourne la note si elle existe ou sinon retourne l'identifiant et avec une value null

* Supprimer une note :
>DELETE http://localhost:58883/Note/{Identifiant} (Remplacer **{identifiant}** par l'identifiant de la note que on souhaite supprimer)
>Retourne un bool�en si sa a bien �tait supprimer

Les r�ponses sont au format JSON par d�faut, mais on peut changer le format en XML, HTML....


### Description du code :
----

Le code se s�pare en plusieurs fichiers :
* Controller/NoteController.cs
>S'occupe de la partie HTTP et redirige apr�s dans les bonnes m�thodes correspondante

* Models/RedisConnect.cs
>S'occupe de toute la partie en communication directe avec REDIS

* Models/Note.cs
>Class qui correspond a une note

* Models/Data
>Retranscription des data de REDIS en Key/Value (Value �tait un objet de type Note)