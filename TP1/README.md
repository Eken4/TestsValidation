Le code original ne permet pas d'exécuter des tests de manière satisfaisante.
Seulement deux méthodes dans chaque classe renvoient une réponse, et les données utilisées sont des champs de la classe et non des paramètres de la méthode, on ne peut pas faire d'injection de dépendances.

On commence par supprimer le code mort et le code dupliqué.