# FalloutComputerHackHelper

Application Unity qui sert d'**assistant pour le mini-jeu de piratage des terminaux de Fallout** (wordle-like : deviner le mot de passe à partir du nombre de lettres correctes renvoyé par le terminal).

L'application permet de saisir la liste de mots proposés par le terminal, de configurer un piratage (nombre d'essais, mots à tester), puis de suivre les essais : chaque lettre se voit attribuer un état (utilisée, non utilisée, indéterminée) mis en évidence par un code couleur, et le solveur propose des mots candidats.

## Fonctionnalités

- **Gestion de la bibliothèque de mots** : ajout, modification et suppression de mots, avec persistance locale (sauvegarde/chargement des données).
- **Configuration d'un piratage** : sélection des mots de la session et du nombre d'essais maximum.
- **Solveur de piratage** : à chaque essai (mot + nombre de lettres correctes), il met à jour les statistiques par caractère :
  - `0` lettre correcte → caractère **non utilisé** ;
  - toutes les lettres correctes → caractère **utilisé** ;
  - cas intermédiaire → **indéterminé** (avec dégradé de couleur selon le nombre d'occurrences).
- **Interface à états** : menu principal, écran de statistiques, configuration, puis écran de piratage, avec overlays de confirmation d'action.

## Prérequis

- [Unity](https://unity.com/) **2022.3.60f1** (LTS)
- Un éditeur compatible (Visual Studio, Rider ou VS Code)

## Installation

```bash
git clone https://github.com/LepetitPortfolio/FalloutComputerHackHelper.git
```

1. Ouvrir le dossier du projet dans Unity Hub (version 2022.3.60f1).
2. Laisser Unity importer les packages et les assets.
3. Ouvrir la scène `Assets/Scenes/SampleScene.unity` et appuyer sur **Play**.

## Utilisation

1. **Menu principal** → ajouter les mots proposés par le terminal Fallout dans la bibliothèque (ils sont sauvegardés automatiquement).
2. **Configuration** → sélectionner les mots de la session et définir le nombre d'essais autorisés.
3. **Piratage** → saisir le mot essayé et le nombre de lettres correctes renvoyé par le terminal ; le solveur met à jour les couleurs des lettres et affiche les suggestions pour l'essai suivant.

## Architecture

Projet Unity (C#) organisé autour de singletons accessibles via la classe statique `LibraryFunctions` :


| Dossier                    | Rôle                                                                                                        |
| -------------------------- | ----------------------------------------------------------------------------------------------------------- |
| `Scripts/Enums`            | États du jeu (`EGameState`) et des caractères (`ECharacterStat`)                                            |
| `Scripts/HackSolver`       | `HackSolver` : logique de résolution ; `CharacterStat` : statistiques par lettre                            |
| `Scripts/LibraryFunctions` | Accesseurs statiques (managers, solveur), sauvegarde/chargement, utilitaires                                |
| `Scripts/Managers`         | `WordsManager` (bibliothèque de mots), `CanvasManager` (navigation UI), `SaveLoadDataManager` (persistance) |
| `Scripts/SaveSystem`       | `AppData` (données sérialisables) et `FileDataHandler` (lecture/écriture)                                   |
| `Scripts/Structs`          | Structures utilitaires (`Try`, `CanvasState`, `CanvasOverlay`, `CharactertStatColor`)                       |
| `Scripts/UI`               | Composants d'interface : panneaux d'ajout/modification de mots, configuration, lignes de mots               |
| `Scripts/WordLine`         | `WordLine` : affichage d'un mot dans une liste                                                              |


Principaux packages Unity : TextMeshPro, uGUI, Adaptive Performance, Visual Scripting, Test Framework.

## Roadmap

- Compléter la génération de suggestions (`GenerateSugests`) pour filtrer les mots candidats compatibles avec les essais précédents.

## Licence

À définir par l'auteur (aucune licence n'est actuellement précisée dans le dépôt).

---
