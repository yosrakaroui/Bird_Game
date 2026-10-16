Bird Game

*Bird Game* est un jeu d’arcade en 2D inspiré du principe de *Flappy Bird*. Le joueur guide un oiseau à travers une succession de passages entre des tuyaux. Le défi consiste à garder l’oiseau en l’air, à éviter les obstacles et à accumuler des points jusqu’à atteindre les seuils nécessaires pour progresser entre les niveaux.

## Principe et contrôles

L’oiseau est soumis à la gravité et descend naturellement. Un appui sur la **barre d’espace** lui donne une impulsion verticale vers le haut. Il faut donc doser les appuis et les répéter au bon moment pour maintenir sa trajectoire et franchir l’ouverture entre chaque paire de tuyaux.

L’animation des ailes alterne les sprites d’aile haute et d’aile basse pendant que l’oiseau est vivant. Elle ne modifie pas la position ni la vitesse de l’oiseau : le déplacement reste contrôlé par la physique du jeu et par l’impulsion donnée avec Espace.

## Obstacles et score

Les tuyaux sont créés régulièrement à droite de l’écran. Leur hauteur varie de manière aléatoire, ce qui change la position du passage à franchir. Ils se déplacent ensuite vers la gauche et sont supprimés lorsqu’ils quittent la zone de jeu.

Quand l’oiseau traverse l’espace entre les tuyaux, le score augmente d’un point. L’interface affiche le score ainsi que la progression du niveau vers le seuil de passage.

## Les trois niveaux

Le jeu comprend trois scènes, avec une difficulté croissante :

- **Niveau 1 — prairie** : fond bleu, tuyaux verts et intervalle d’apparition le plus lent.
- **Niveau 2 — désert** : fond brun-orangé et tuyaux orange. Les tuyaux arrivent plus souvent et se déplacent plus vite.
- **Niveau 3 — nuit** : fond bleu-violet et tuyaux bleu clair. Le rythme des tuyaux est le plus rapide.

Dans chaque niveau, le joueur doit marquer **10 points** pour passer au suivant. Le niveau 1 ouvre le niveau 2, qui ouvre à son tour le niveau 3. Le dernier niveau n’a pas de niveau suivant.

## Fin de partie et redémarrage

Une collision avec un tuyau ou un autre obstacle arrête la partie et affiche l’écran **Game Over**. Le jeu joue alors un son de collision et désactive la génération de nouveaux tuyaux. Le bouton **Play Again** recharge la scène en cours pour recommencer le niveau. À la fin d’une partie dans le niveau 3, l’écran affiche également un message de fin des trois niveaux.

## Sons et éléments visuels

Trois effets sonores accompagnent les actions principales : le battement au saut, le passage d’un tuyau qui rapporte un point et la collision. Les ailes sont jaunes et contrastent avec le corps rouge de l’oiseau ainsi qu’avec les fonds distincts des niveaux.///


