# GranjeroSaltador

## Movimiento y salto del personaje

El personaje estará situado a la izquierda de la pantalla y aparentará moverse hacia la derecha. Pero
su movimiento se hará con una técnica muy empleada en este tipo de juegos que consiste en que el
personaje en realidad no se mueve (lo que, de paso, evita tener que mover la cámara) y es el fondo
el que se mueve en dirección contraria, de derecha a izquierda, en este caso.

Para conseguir el efecto correcto aprovecharemos que la imagen de la que disponemos para el
fondo es en realidad una imagen duplicada a lo ancho, de modo que podemos hacer que parezca un
movimiento continuo e infinito si la movemos hacia la derecha en el momento y distancia
adecuados.

Tendremos en cuenta que el movimiento hacia la izquierda del fondo deberá ser realizado también
por otros objetos, así que separaremos en scripts diferentes este movimiento y el traslado hacia la
derecha para “reciclar” la imagen.

El personaje deberá al presionar la barra espaciadora, pero solo si está en tierra. Para realizar el
salto se hará aplicando una fuerza de impulso de valor 8. Esto requiere que el personaje tenga un
Rigidbody que debemos agregar.

## Animación del personaje
El personaje del granjero lleva incorporado un animador que utilizaremos para darle vida. Este
animador está controlado por numerosos parámetros, de los que a nosotros nos interesan solo
algunos.

Para empezar, y dado que el personaje siempre se moverá a velocidad constante, podemos
establecer directamente en el animador un valor lo suficientemente alto del parámetro speed_f para
que ejecute la animación de correr.

Usaremos también jump_trig, y jump_b. El primero es un trigger y nos permitirá iniciar los saltos.
El segundo es un booleano, asociado también a los saltos, y lo utilizaremos para hacer una
transición desde el salto a una animación de caida y luego vuelta de nuevo a la animación de correr.

También utilizaremos el parámetro death_type para seleccionar el tipo de animación de muerte
que ejecutará el personaje.

## Espaneo de obstáculos
Crearemos un GameManager que se encargará de ir sembrando de obstáculos el camino de nuestro
atlético granjero. Mediante una corrutina, se espaneará una barrera cada cierto tiempo elegido
aleatoriamente entre 1 y 4 segundos.

Lógicamente las barreras tienen que correr hacia la izquierda al mismo ritmo que el fondo de
pantalla. Deberemos poder usar el mismo script que hemos usado para el fondo.

Se establecerá un sistema de reciclado de barreras. Aquellas que superen un cierto punto en su
movimiento hacia la izquierda, serán desactivas y colocadas en un pool a la espera de poder ser
usadas de nuevo. Cuando se deba colocar una nueva barrera se comenzará por comprobar si hay
alguna disponible en el pool de desactivadas y de ser así se usará una de ellas. En caso de no haber
disponibles se espaneará una nueva.

## Choque con la barrera y muerte del personaje
Si el personaje del granjero choca con una barrera se ejecutará una animación de muerte, que se
seleccionará aleatoriamente estableciendo un valor entre 0 y 2 para el parámetro death_type del
animador, se pararán todos los movimientos hacia la izquierda para que desaparezca la sensación de
movimiento hacia la derecha del personaje y éste dejará de responder saltando a la espaciadora.
Todo esto se coordinará desde el GameManager, que será avisado del choque y establecerá la
condición de GameOver
