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
│   ├── Animation               # Animations utilisées dans le projet
│   ├── Audio                   # Sons du projet
│   │   ├── Environment         # Sons d'ambiance (vent, neige, nature, etc.)
│   │   ├── Feedback            # Sons de feedback utilisateur (ex : prise d'objet)
│   │   └── UI                  # Sons de l'interface utilisateur (boutons, menus, etc.)
│   ├── LucirgoSoft             # Assets venant du pack LucirgoSoft
│   │   └── LCRG Montains       # Pack montagne
│   ├── Materials               # Matériaux du projet
│   │   ├── Mont_Materials      # Matériaux spécifiques aux montagnes
│   │   ├── Mountain_Snow_Materials  # Matériaux pour la neige
│   │   └── Polygon-Lite Survival_Materials  # Matériaux du pack Polygon-Lite
│   ├── Models                  # Modèles 3D
│   │   ├── Characters          # Modèles 3D des personnages
│   │   └── Environment         # Modèles 3D de l’environnement
│   │       └── Mont_Fbx        # Modèles 3D liés aux montagnes
│   ├── Plugins                 # Scripts ou plugins tiers
│   ├── Polygon-Lite Survival Collection # Pack d'assets Polygon-Lite
│   │   ├── Demo_Day_Profiles   # Profils de lumière ou post-processing
│   │   ├── Models              # Modèles 3D
│   │   ├── Prefabs             # Prefabs liés au pack
│   │   ├── Scenes              # Scènes de démonstration du pack
│   │   │   └── Demonstration   # Scène de test fournie avec le pack
│   │   └── Textures            # Textures du pack
│   ├── Prefabs                 # Objets préfabriqués (réutilisables)
│   │   ├── Environment         # Éléments de décor
│   │   │   ├── Mountain_Prefabs # Montagnes en prefab
│   │   │   └── Mountain_Snows_Prefab  # Montagnes enneigées en prefab
│   │   ├── Interactive         # Objets interactifs (poubelles, obstacles, etc.)
│   │   └── Trash               # Objets de type déchets
│   ├── Resources               # Contient des fichiers accessibles à runtime
│   │   └── Data                # Données sauvegardées (scores, paramètres)
│   ├── Scenes                  # Contient toutes les scènes Unity
│   │   ├── Montain_Scene       # Scène spécifique aux montagnes
│   │   │   └── anim            # Animations spécifiques aux scènes montagne
│   │   └── Mountain_Snow_Scenes # Scènes enneigées
│   ├── Scripts                 # Scripts du projet
│   │   ├── Debug               # Scripts liés aux outils de debug
│   │   ├── Gameplay            # Scripts des mécaniques du jeu
│   │   └── UI                  # Scripts pour l'interface utilisateur
│   ├── Snow Mountain           # Contient des assets de neige/montagne
│   │   └── Source
│   │       ├── cubemap         # Images utilisées pour les ciels en cubemap
│   │       ├── fbx             # Modèles 3D en FBX
│   │       │   └── Materials   # Matériaux liés aux modèles FBX
│   │       └── tga             # Textures en format TGA
│   ├── Standard Assets         # Assets standards Unity
│   │   └── Prototyping         # Assets de prototypage Unity (textures, modèles, etc.)
│   │       ├── Materials       # Matériaux
│   │       ├── Models          # Modèles 3D
│   │       ├── Prefabs         # Objets préfabriqués
│   │       └── Textures        # Textures
│   ├── Textures                # Contient toutes les textures
│   │   ├── Mont_Textures       # Textures des montagnes
│   │   └── Tree_Textures       # Textures spécifiques aux arbres
│   ├── UI                      # Éléments de l’interface utilisateur
│   │   ├── Buttons             # Boutons et icônes
│   │   └── Panels              # Panneaux et fenêtres
│   └── XR                      # Ressources spécifiques à la réalité virtuelle (VR)
│       ├── Menu                # Menu XR et interfaces immersives
│       │   └── Loaders         # Gestion des scènes et du chargement
│       ├── Interaction         # Scripts et prefabs pour l'interaction XR
│       │   └── Settings        # Paramètres XR spécifiques
├── Documentation               # Contient la documentation du projet
├── Library                     # Dossier généré automatiquement par Unity
├── Logs                        # Logs pour le débogage
├── Packages                    # Gestionnaire de packages Unity
├── ProjectSettings             # Paramètres du projet Unity
├── Temp                        # Fichiers temporaires générés par Unity
├── UserSettings                # Paramètres utilisateur Unity
├── rclone-v1.69.0-windows-amd64 # Dossier d’outil à ignorer dans Git
└── README.md                   # Documentation du projet


