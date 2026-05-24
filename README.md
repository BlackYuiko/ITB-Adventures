# ITB Adventures

## Descripción

ITB Adventures es un pequeño juego de plataformas 2D donde el jugador debe explorar el mapa, recoger monedas, resolver pequeños puzzles y derrotar enemigos hasta llegar al trofeo final.

El juego dispone de 4 escenas principales:

- Intro
- Juego
- Final
- Game Over

Durante la partida el jugador puede:

- Moverse y saltar
- Atacar enemigos
- Perder vidas
- Recoger monedas
- Resolver un puzzle de palancas
- Completar el nivel alcanzando el trofeo final

---

# Tecnologías utilizadas

- Unity 6.4
- Visual Studio 2026
- C#
- Sistema de físicas 2D de Unity
- Animator y animaciones

---

# Arquitectura del proyecto

Para mejorar la organización del código se ha implementado un sistema de managers y eventos.

## GameManager

El `GameManager` está implementado como Singleton y utiliza `DontDestroyOnLoad()` para persistir entre escenas.

Se encarga de:

- Gestión de vidas
- Gestión de monedas
- Cambio de escenas
- Game Over
- Reinicio de partida

---

## Eventos

Se utiliza un sistema de eventos (`GameEvents`) para desacoplar la comunicación entre objetos.

Ejemplos:

- `OnLivesChanged`
- `OnCoinsChanged`
- `OnPlayerDeath`

La UI escucha estos eventos para actualizarse automáticamente sin referencias directas al jugador.

---

## Otros managers

### MusicManager
Gestiona la música del juego y persiste entre escenas.

### DualLevelManager
Controla el puzzle de las dos palancas necesario para avanzar en el nivel.

---

# Características implementadas

- Movimiento 2D
- Sistema de salto
- Ataque cuerpo a cuerpo
- Enemigos con daño
- Sistema de vidas con corazones
- Sistema de monedas
- UI dinámica
- Pantalla de victoria
- Pantalla de Game Over
- Puzzle interactivo
- Persistencia entre escenas
- Arquitectura basada en eventos

---

# Assets y música

Los assets gráficos, sonidos y música utilizados en el proyecto no son de mi propiedad.

Todos los recursos utilizados son libres de copyright o de uso gratuito para proyectos educativos.

---

# Autor

Proyecto realizado por BlackYuiko como práctica de clase.
