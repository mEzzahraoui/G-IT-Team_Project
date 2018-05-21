# G-IT-Team
<h2> Sprint 1</h2> </br>
<h3> MiniBacklog sprint-1</h3> </br>
<table style="width:100%">
<tr>
	<th>Id</th>
	<th>User Story</th> 
	<th>Priorité</th>
	<th>Difficulté</th>
	<th>Etat</th>
</tr>
<tr>
	<td>1</td>
	<td>En tant que développeur, je souhaite m’inscrire dans l’application en donnant mon email et mon mot de passe.</td> 
	<td>1</td>
	<td>8</td>
	<td></td>
</tr>

<tr>
	<td>2</td>
	<td>En tant que développeur, je souhaite pouvoir me connecter/déconnecter afin d’utiliser/quitter l’application.</td> 
	<td>1</td>
	<td>5</td>
	<td></td>
</tr>

<tr>
	<td>3</td>
	<td>En tant que développeur, je souhaite pouvoir créer une équipe de projet en lui donnant un nom ,afin de commencer à travailler sur un projet.</td> 
	<td>1</td>
	<td>5</td>
	<td></td>
</tr>

<tr>
	<td>4</td>
	<td>En tant que développeur, je souhaite pouvoir obtenir la liste des équipes dont je suis membre afin de voir leur composition</td> 
	<td>4</td>
	<td>3</td>
	<td></td>
</tr>
<tr>
	<td>5</td>
	<td>En tant que développeur, je souhaite pouvoir inviter un autre membre dans mon équipe de projet afin de l’intégrer dans mon équipe.</td> 
	<td>4</td>
	<td>5</td>
	<td></td>
</tr>
</table>

<h3>Taches Sprint-1</h3></br>

<table style="width:100%">
<tr>
	<th>Id tache</th>
	<th>User Story</th> 
	<th>Id User Story</th>
	<th>Personne en charge</th>
</tr>
<tr>
	<td>1</td>
	<td>Rédiger le test E2E US1 :</br>
	Écrire le test E2E pour la US1 qui décrit un sénario d'inscription (remplir le formulaire d'inscription et accéder directement à l'application si l'inscription se fait avec succès sinon se rediriger vers la page d'inscription)
	</td> 
	<td>1</td>
	<td></td>
</tr>

<tr>
	<td>2</td>
	<td>Rédiger le test E2E US2 :</br>
	Écrire le test E2E pour la US2 qui décrit un sénario d'authentification (saisie de l'email et password et si ils sont validés se rediriger vers la page d'acceuil de l'application , et si ce n'est pas le cas se rediriger vers la page d'authentification)
	</td> 
	<td>2</td>
	<td></td>
</tr>

<tr>
	<td>3</td>
	<td>Rédiger le test E2E US3 :</br>
	Écrire le test E2E pour la US3 qui décrit un sénario de création d'un projet (remplir le formulaire de création d'un projet et si le projet est créé avec succès se redériger vers le tableau de bord de ce projet sinon ce rediriger vers la page de création d'un projet )
	</td> 
	<td>3</td>
	<td></td>
</tr>

<tr>
	<td>4</td>
	<td>Rédiger le test E2E US4 :</br>
	Écrire le test E2E pour la US4 qui décrit un scénario obtention de la liste des équipes ()</td> 
	<td>4</td>
	<td></td>
</tr>
<tr>
	<td>5</td>
	<td>Rédiger le test E2E US4 :</br>
	Écrire le test E2E pour la US5 qui décrit un scénario d'invitation de membre ( remplir un formulaire d'invitation (nom de la personne et de l'équipe), si échec affiche un message d'érreur )</td> 
	<td>5</td>
	<td></td>
</tr>
<tr>
	<td>6</td>
	<td>Configuration du serveur NodeJs :</br>
	Créer un squelette d'un projet nodejs</br>
	Installer les dépendances : express,path,body,cors,express-myconnection,mysql,nodemon</br>
	Faire la liaison avec la base de données Mysql</br>
	Configurer la partie front-end du projet (Angular) :</br>
	Créer un squelette d'un projet angular</br>
	Installer Bootstrap</br>
	Mettre en place un systeme de routage entre les composants d'Angular</br>
	Mettre en place Protractor pour les tests E2E</br>
	</td> 
	<td></td>
	<td></td>
</tr>

<tr>
	<td>7</td>
	<td>Mettre en place la base de données</br>
	Création de la table "UTILISATEURS"</br>
	id : int</br>
	email : String</br>
	password : String</br>
	Création de la table "PROJETS"</br>
	id : int</br>
	nom : String</br>
	MCréation de la table "ÉQUIPES"</br>
	idprojet : int</br>
	idutilisateur : int</br>
	</td> 
	<td></td>
	<td></td>
</tr>

<tr>
	<td>8</td>
	<td>Définir les intérations entre la couche métier et la couche données pour la US1 (écrire les requêtes SQL) : </br>
	Écrire la requête SQL qui permet d'ajouter un nouvel utilisateur à la table "UTILISATEURS"</br>
	Écrire la requête SQL qui permet de verifier l'existance d'un utilisateur dans la table "UTILISATEURS"</br>
	Écrire la requête SQL qui permet de verifier si un email exist dans la table "UTILISATEURS"</br>
	</td>
	<td>1</td>
	<td></td>
</tr>

<tr>
	<td>9</td>
	<td>Définir les intérations entre la couche métier et la couche données pour la US2 (écrire les requêtes SQL) : </br>
	Écrire la requête sql qui permet de vérifier la présence d’un enregistrement dans la table "UTILISATEURS" correspondant aux informations envoyés (login/pwd)</br>
	</td>
	<td>2</td>
	<td></td>
</tr>

<tr>
	<td>10</td>
	<td>Définir les intérations entre la couche métier et la couche données pour la US3 (écrire les requêtes SQL) :</br>
	Écrire la requête SQL qui permet d'ajouter une équipe à la table "ÉQUIPES"</br>
	Écrire la requête SQL qui permet d'ajouter un projet à la table "PROJETS"</br>
	Écrire la requête SQL qui associe le projet et l'utilisateur à la table "ÉQUIPES"</br>
	</td>
	<td>3</td>
	<td></td>
</tr>

</table>