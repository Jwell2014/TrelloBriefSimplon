# TrelloBriefSimplon

Ce projet est une application inspirée de Trello, développée dans le cadre de la formation Simplon. Il s'agit d'une application web complète comprenant un **backend** développé en C# et un **frontend** conçu avec React. L'objectif est de permettre une gestion efficace des tâches et des tableaux de manière intuitive.

---

## 🚀 Fonctionnalités principales

### Gestion des utilisateurs :
- Création de compte et connexion.
- Gestion des profils utilisateur.

### Gestion des tableaux et tâches :
- Création, modification et suppression de tableaux.
- Ajout, mise à jour et suppression de tâches.
- Organisation des tâches par colonnes (Kanban).

### Interface utilisateur moderne :
- Conçue avec React et les bibliothèques **PrimeReact/PrimeFlex** pour une expérience utilisateur fluide.

### API documentée avec Swagger :
- Documentation interactive pour tester les endpoints.

---

## 📂 Structure du projet

Le projet est organisé en deux parties :


## Backend

### Technologies :
- **Langage** : C#
- **Base de données** : MySQL (gérée via phpMyAdmin)
- **Documentation API** : Swagger
- **API REST** : Gestion des utilisateurs, tableaux et tâches.
- **Authentification** : JWT (JSON Web Token) pour sécuriser les endpoints.

---

## Frontend

### Technologies :
- **Langage** : React
- **Bibliothèques** : PrimeReact, PrimeFlex
- **Consommation d'API** : Axios pour les appels vers le backend.
- **Design responsive** : Optimisé pour les écrans de bureau et mobiles.

# Démarrage avec Create React App

Ce projet a été initialisé avec [Create React App](https://github.com/facebook/create-react-app).

## Scripts disponibles

Dans le répertoire du projet, vous pouvez exécuter :

### `npm start`

Lance l'application en mode développement.\
Ouvrez [http://localhost:3000](http://localhost:3000) pour voir l'application dans le navigateur.

La page se rechargera si vous apportez des modifications.\
Vous verrez également les erreurs de lint dans la console.

### `npm test`

Lance le test runner en mode interactif.\
Consultez la section sur [l'exécution des tests](https://facebook.github.io/create-react-app/docs/running-tests) pour plus d'informations.

### `npm run build`

Construit l'application pour la production dans le dossier `build`.\
Il regroupe correctement React en mode production et optimise la construction pour obtenir les meilleures performances.

La construction est minifiée et les noms de fichiers incluent les hachages.\
Votre application est prête à être déployée !

Consultez la section sur [le déploiement](https://facebook.github.io/create-react-app/docs/deployment) pour plus d'informations.

### `npm run eject`

**Note : c'est une opération sans retour. Une fois que vous avez `eject`, vous ne pouvez plus revenir en arrière !**

Si vous n'êtes pas satisfait de l'outil de construction et des choix de configuration, vous pouvez `eject` à tout moment. Cette commande supprimera la dépendance de construction unique de votre projet.

Au lieu de cela, elle copiera tous les fichiers de configuration et les dépendances transitives (webpack, Babel, ESLint, etc.) directement dans votre projet afin que vous ayez un contrôle total sur eux. Toutes les commandes sauf `eject` fonctionneront toujours, mais elles pointeront vers les scripts copiés afin que vous puissiez les modifier. À ce stade, vous êtes seul.

Vous n'avez jamais besoin d'utiliser `eject`. L'ensemble des fonctionnalités sélectionnées est adapté aux déploiements petits et moyens, et vous ne devriez pas vous sentir obligé d'utiliser cette fonctionnalité. Cependant, nous comprenons que cet outil ne serait pas utile si vous ne pouviez pas le personnaliser lorsque vous êtes prêt.

## En savoir plus

Vous pouvez en savoir plus dans la [documentation Create React App](https://facebook.github.io/create-react-app/docs/getting-started).

Pour apprendre React, consultez la [documentation React](https://reactjs.org/).
