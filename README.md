# 🐾 Tamagotchi AR

Une expérience de Tamagotchi en Réalité Augmentée réalisée avec Unity + Vuforia.  
Le joueur peut nourrir un Mametchi, le faire sauter, voir une bulle de remerciement, et interagir dans un environnement AR mignon et interactif.

## 🎮 Fonctionnalités

- Détection d’image avec Vuforia (Image Target)
- Mametchi 3D interactif : saute lorsque cliqué
- Panier de fraises → clic pour faire apparaître des fraises en arc
- Mametchi mange les fraises → animation + détection
- Bulle “Merci” lorsque toutes les fraises sont mangées (animée via Animator)
- UI fixe : bouton “Quit” en Screen Space Overlay
- Son kawaii au clic des fraises et du bouton quitter

## 🛠️ Technologies utilisées

- Unity 6.x (Universal Render Pipeline)
- Vuforia Engine
- C#
- TextMeshPro
- Audio : fichiers kawaii click + pop sound

## 🗂️ Structure de la scène

ARCamera
├── ImageTarget
│   ├── Canvas
│   │   ├── Mametchi
│   │   ├── FraisesContainer
│   │   └── MerciBubble (désactivé au démarrage)
│   ├── ArcPreview (pour gizmo arc fraises)
│   └── FeedManager
├── UI_Canvas (Screen Space Overlay)
│   ├── QuitButton
│   └── DialogueBox (optionnel)



## 💻 Installation

1. Cloner le projet : https://github.com/tonCompte/tonProjetUnity.git
2. Ouvrir sous Unity 6.x avec Vuforia activé.
3. Importer Vuforia Engine si besoin via Package Manager.
4. Remplacer l’image cible dans Vuforia → Image Target par votre image personnalisée.
5. Lancer la scène principale : ARCamera.
   
## 🎯 Image Target

Pour tester le projet, vous devez utiliser l’image suivante comme cible Vuforia.

📥 **Fichier :** `Assets/AR_Targets/tamagotchi_target.png`

📋 **Utilisation :**
- Imprimez ou affichez cette image sur un écran.
- Lancez la scène dans Unity → `ARCamera`.
- Pointez la caméra du téléphone ou webcam vers l’image pour activer l’AR.

## ✅ Utilisation

- Pointer la caméra vers l’image cible (exemple : empreinte + texte Tamagotchi)
- Cliquer sur Mametchi → il saute et joue un son
- Cliquer sur le panier de fraises → spawn de fraises en arc
- Cliquer sur une fraise → elle disparaît (mangée)
- Lorsque toutes les fraises sont mangées → apparition d’une bulle Merci !
- Appuyer sur Quit → retour au menu principal

## 💡 Remarques

- MerciBubble est désactivé au lancement via le script FeedManager.
- Les fraises sont générées en arc réglable (ArcPreview.cs).
- Tous les sons sont assignés dans l’inspector (FeedManager, QuitARButton).

## 🎨 Crédit assets

- Modèle 3D Mametchi : ressources libres
- Sons : kawaii click, pop → libres
- Icônes UI : Pixel art inspiré

## 👩‍💻 Auteur

Projet réalisé par **Chloé CHIARLINI** dans le cadre d’un prototype Unity AR.
