## Description

Ceci est une application compagnon pour le jeu de société Almost Innocent, permettant de jouer aux différents scénarios en solo. Le jeu de base est requis ainsi qu'une connaissance des règles.

Le but du jeu sera de trouver la combinaison qu'a pioché MIA (votre adversaire IA). 
Comme dans le jeu de base, vous serez autorisé à lui poser l'une des deux questions suivantes :
- Combien d'indices me concernent dans cette ligne/colonne ?
- Est-ce que ma Victime/Coupable/preuve/Lieu/Crime se trouve dans cette ligne/colonne ?

De même, une colonne ou une ligne ne pourra recevoir qu'un seul jeton enquête, peu importe le côté où vous posez le jeton.

Une fois les jetons enquête épuisés, vous devez procéder à la résolution de votre combinaison.
Une série de questions vous sera posée, si vous trouvez votre combinaison, vous gagnez la partie, MIA répondant toujours correctement à la résolution de sa combinaison.

## TODO
- [ ] Ajouter les scénarios
  - [x] Scénario 1
  - [x] Scénario 2
  - [x] Scénario 3
  - [x] Scénario 4
  - [x] Scénario 5
  - [x] Scénario 6
  - [x] Scénario 7
  - [ ] Scénario 8
  - [ ] Scénario 9
  - [ ] Scénario 10
  - [ ] Scénario 11A
  - [ ] Scénario 11B
- [x] Ajouter les niveaux de difficultés
  - [x] FACILE
  - [x] MOYEN
  - [x] DETECTIVE
- [x] Ajouter les cartes
  - [x] CRIME
  - [x] VICTIME
  - [x] PREUVE
  - [x] LIEU
  - [x] COUPABLE
- [x] Ajouter les cartes spéciales
  - [ ] COUPABLE
  - [ ] PREUVE
  - [ ] VICTIME
- [ ] Ajouter les capacités des personnages
  - [x] DIN
  - [ ] TEOR
  - [ ] EDD
  - [ ] OKRA
  - [ ] VALIA
- [ ] Ajouter les modules
  - [ ] REINE
- [ ] Améliorer la gestion de l'IA
  - [ ] Pouvoir définir son comportement sur l'utilisation des jetons
    - [ ] Avoir un comportement pour utiliser un jeton qui est en majorité
    - [ ] Avoir un comportement pour utiliser un jeton qui est en minorité
    - [ ] Avoir un comportement pour utiliser une ligne ou une colonne qui aide le plus possible le joueur en fonction de son avancée
- [ ] Ajouter la gestion des parties 
  - [ ] Sauvegarder le résultat de la partie
  - [ ] Consulter les parties jouées
  - [ ] Déterminer les points en fin de partie