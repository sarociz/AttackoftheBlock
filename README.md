# AttackoftheBlock
   + Vamos a crear un minijuego 2D. Para ello, crear un proyecto de Unity 2D
   + El personaje será un sprite que debe moverse constantemente a la posición del ratón/cursor, es decir, se moverá con el movimiento del ratón
   + Este personaje deberá evitar una serie de “bloques” que estarán rebotando contra los límites de la pantalla
   + Los límites de la pantalla los marca el field of view (fov) de la cámara
   + El juego termina cuando el player colisiona contra alguno de los “enemigos”
   + Haz que el juego se termine de alguna manera: pantalla de game over, utilizando Application.Quit(), como quieras...
   + Los elementos gráficos son libres. Utilizad lo que queráis
   + Elementos que se utilizan:
        +Sprites
        +Colliders 2D
        +Cámara
        +PhysicsMaterials 2D
        +Scripts (con variables públicas y privadas). ¡COMENTAR CÓDIGO!
        +Funciones de callback como: OnTriggerEnter, OnTriggerStay, OnTriggerExit, OnCollisionEnter, OnCollisionStay, OnCollisionExit... (a gusto)
