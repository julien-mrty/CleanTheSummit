# Clean the Summit – Projet VR (Développement Durable)

Bienvenue sur le projet **Clean the Summit**. Ce projet VR a pour objectif de sensibiliser au **tri des déchets** et au **développement durable** dans un contexte inspiré des problématiques écologiques de l’Everest.

---

## Version Unity

- **Version recommandée** : `Unity 2020.3.33f1`.  
- Vérifiez dans `ProjectSettings/ProjectVersion.txt` pour confirmer la version exacte du projet.  
- Si vous utilisez Unity Hub, assurez-vous de bien installer la **même version** avant d’ouvrir le projet.

---

## Conventions de Nommage

Afin de faciliter la collaboration, veuillez respecter les règles suivantes :

- **Scripts (C#)**  
  - Nom de classe : **PascalCase** (ex. `ScoreManager.cs`, `PlayerController.cs`).  
  - Variables : **camelCase** (ex. `playerScore`, `maxItems`).  

- **Assets graphiques**  
  - **Prefabs** : `PF_NomObjet`, par ex. `PF_Trash`, `PF_Poubelle`.  
  - **Matériaux** : `Mat_NomObjet`, par ex. `Mat_Rock`.  
  - **Textures** : `Tex_NomObjet_Type`, par ex. `Tex_Rock_Albedo`, `Tex_Rock_Normal`.  
  - **Modèles 3D** : `Model_NomObjet`, par ex. `Model_Rock.fbx`.  

- **Scènes**  
  - `Scene_NomScene`, par ex. `Scene_MainMenu`, `Scene_Level1`.

L’objectif est de maintenir une cohérence et de rapidement identifier le type de fichier.

---

## Workflow Git et Branches

1. **Branche `main` ou `master`**  
   - Contient la version stable du projet.

2. **Branches de fonctionnalités**  
   - Pour chaque fonctionnalité ou ajout d’assets, créez une branche dédiée :  
     - Exemple : `feat/add-rock-assets`, `feat/gameplay-score`.

3. **Pull Requests**  
   - Ouvrez une Pull Request (PR) de votre branche vers `main`.  
   - David (intégrateur Unity) valide et fusionne après relecture.
---
## Mise à Jour du .gitignore

### Objectif
Le fichier `.gitignore` a été mis à jour pour exclure des fichiers inutiles et volumineux du dépôt, tout en documentant les meilleures pratiques pour que l'équipe puisse travailler de manière efficace.

### Changements Apportés

1. **Exclusion des fichiers générés automatiquement par Unity :**
   - Exclusion des dossiers `Library`, `Temp`, `Logs`, `UserSettings` et autres fichiers temporaires.
   - Ces fichiers sont générés automatiquement par Unity et ne doivent pas être versionnés.

2. **Gestion des Assets Lourds :**
   - Les dossiers contenant des fichiers volumineux (modèles 3D, textures, audio) sont exclus.
   - Exemple : `/Assets/Models/`, `/Assets/Textures/`, `/Assets/Audio/`.

3. **Exclusion des Plugins Tiers et des Caches :**
   - Plugins tiers non utilisés (exemple : JetBrains Rider, Collaborate cache).
   - Dossier `.vs/` pour Visual Studio.

4. **Support pour XR et VR/AR :**
   - Dossier `/Assets/XR/XRPluginManagement/` ajouté si inutilisé.


#### Voici un extrait du fichier `.gitignore` mis à jour :

```plaintext
# Unity auto-generated files
/[Ll]ibrary/
/[Tt]emp/
/[Oo]bj/
/[Bb]uild/
/[Bb]uilds/
/[Ll]ogs/
/[Uu]ser[Ss]ettings/

# Large assets
/Assets/Models/
/Assets/Textures/
/Assets/Audio/
/Assets/SharedAssets/

# XR plugin folders (if unused)
/Assets/XR/XRPluginManagement/

# Visual Studio cache
.vs/

# Unity Collaborate cache
/Collab/
```

---
## Structure des Dossiers

Le projet est organisé comme suit :



```plaintext
CleanTheSummit
├── Assets
│   ├── Scripts               # Contient tous les scripts de gameplay et système
│   │   ├── Gameplay          # Scripts liés aux mécaniques du jeu (ex : ScoreManager.cs)
│   │   ├── UI                # Scripts pour l'interface utilisateur (ex : MenuController.cs)
│   │   └── Debug             # Scripts pour le mode debug (ex : DebugConsole.cs)
│   ├── Scenes                # Contient toutes les scènes Unity du projet
│   │   ├── MainMenu.unity    # Menu principal
│   │   ├── Level1.unity      # Niveau 1
│   │   ├── Level2.unity      # Niveau 2
│   │   └── Level3.unity      # Niveau 3
│   ├── Prefabs               # Préfabriqués pour réutilisation
│   │   ├── Trash             # Objets déchet (bouteilles, boîtes, etc.)
│   │   ├── Environment       # Éléments de décor (roches, arbres, etc.)
│   │   └── Interactive       # Objets interactifs (poubelles, obstacles, etc.)
│   ├── Models                # Modèles 3D utilisés dans le jeu
│   │   ├── Characters        # Modèles 3D des personnages
│   │   └── Environment       # Modèles 3D des éléments de l'environnement
│   ├── Textures              # Textures appliquées aux modèles et matériaux
│   ├── Materials             # Matériaux pour les objets 3D
│   ├── Audio                 # Fichiers audio
│   │   ├── UI                # Sons pour les interactions utilisateur
│   │   ├── Feedback          # Sons de feedback (ex : prise d'objet, mauvais tri)
│   │   └── Environment       # Sons diégétiques (vent, neige, avalanche)
│   ├── UI                    # Éléments d'interface utilisateur
│   │   ├── Buttons           # Boutons et icônes
│   │   └── Panels            # Panneaux et fenêtres
│   ├── Animation             # Animations pour les personnages et objets
│   ├── Resources             # Fichiers accessibles à runtime
│   │   └── Data              # Données sauvegardées (scores, paramètres)
│   ├── Plugins               # Scripts ou plugins tiers
│   ├── Environment           # Assets liés à l'environnement (roches, neige, tentes)
│   └── XR                    # Ressources spécifiques pour la VR/AR
│       ├── Menu              # Menu XR et fenêtres immersives
│       └── Interaction       # Scripts et prefabs pour l'interaction XR
├── Library                   # Dossier généré automatiquement par Unity
├── Logs                      # Logs pour débogage
├── Packages                  # Gestionnaire de packages Unity
├── ProjectSettings           # Paramètres du projet Unity
├── Temp                      # Fichiers temporaires générés par Unity
├── UserSettings              # Paramètres utilisateur Unity
├── .gitignore                # Fichier pour ignorer les fichiers inutiles dans le versionnement
├── README.md                 # Documentation du projet
└── Documentation             # Notes et guides supplémentaires
    └── Rapport.pdf           # Rapport du projet

