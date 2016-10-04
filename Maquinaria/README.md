#Introducción

Se ha solicitado desarrollar un programa que permita registrar las fallas de funcionamiento de su maquinaria.
Cada máquina se registra por su número de inventario, marca, modelo y año de puesta en funcionamiento en la planta.

Además se lleva un contador que acumula las fallas atendidas por el sector de mantenimiento y un estado funcional actual que se calcula de la siguiente manera.

a)	Si no registra fallas el estado es “NORMAL”

b)	Si registra entre 1 y 10 fallas se define el estado como “IRREGULAR”

c)	Si se encuentra entre 10 y 20 fallas se define el estado como “ATENCION”

d)	Si supera las 20 fallas debe informar que requiere “MANTENIMIENTO URGENTE”


Periódicamente el sector de mantenimiento realiza tareas de reparación sobre todas las máquinas que se encuentran en la situación del punto d) por lo que a finalizar las mismas el registro de fallas debería resetearse a 0 (cero) para comenzar un nuevo ciclo de trabajo.

El programa deberá permitir agregar, modificar y eliminar la información solicitada como así visualizar la lista de máquinas registradas y su estado.

[![Sin título.png](https://s21.postimg.org/4au1l8tbb/Sin_t_tulo.png)](https://postimg.org/image/src7fpu1v/)
