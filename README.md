## Funciones llamadas por el servidor en el cliente

### ChangeStats
Llamada cuando un evento de juego hace que los stats de un jugador cambien

* `PlayerName`: `string` Id de prototipo a usar para el personaje
* `Stats`: Stats actuales del personaje.
    * `Bravery`: `int`
    * `Intelligence`: `int`
    * `Physical`: `int`
    * `Sanity`: `int`

### SetItemList

### PlayerJoinedLobby
Llamada cuando un jugador se une al lobby

### PlayerSelectedCharacter
Llamado cuando alguien del lobby haya seleccionado algun personaje.

* `CharacterSelected`: Id de prototipo a usar para el personaje
* `LobbyName`: Nombre elegido por el jugador para ser mostrado para la profesora o profesor que haya creado el lobby.
* `StartingStats`: Stats iniciales del personaje.
    * `Bravery`: `int`
    * `Intelligence`: `int`
    * `Physical`: `int`
    * `Sanity`: `int`

### StartGame
* `PlayerOrder`: Lista de jugadores
    * `CharacterName`: Id de prototipo a usar para el personaje
    * `TurnThrow`: Tiro de dado para elegir el turno
    * `TurnOrder`: Orden en el que toca este personaje entre los demás

### StartTurn

### MoveCharacterToPosition
### GetItem
### GetOmen
### SolvePuzzle
Llamada cuando este jugador necesita hacer un puzzle.
* `Instructions`: `string`
* `Documentation`: `string` Cadena con el HTML para mostrar documentación para el usuario.
* `InitialWorkspaceConfiguration`: `string` Cadena con el XML para inicializar un workspace de Blockly.
* `PuzzleId`: `string` Identificación del puzzle a realizar.