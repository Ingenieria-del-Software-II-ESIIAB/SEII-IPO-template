# SE-template

# Instrucciones para utilizar esta plantilla de repositorio.

## 1. Clonar el repositorio

Cree el repositorio de su equipo con el nombre **ISII2526TeamName**, utilizando esta plantilla y 
siguiendo las instrucciones disponibles en:  
[https://docs.github.com/es/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template#creating-a-repository-from-a-template](Create a repository from a template - GitHub documentation).



## 2. Configurar el repositorio.

**2.1. En la rama development modificar el archivo `info.yml`.**

info.yml:
```yaml
project:
  name: 'ISII-2526-GrupoX-Team'
  owner: 'GrupoX'
  teamId: 'Team'
  identities: {}
  notifications:
    email: 'member1@gmail.com,member2@gmail.com,member3@gmail.com,member4@gmail.com'
  members:
    member1:
      name: 'Name1'
      surname: 'Surname1' 
      githubUsername: 'Name1gitUserName1'
    member2:
      name: 'Name2'
      surname: 'Surname2' 
      githubUsername: 'Name1gitUserName2'
    member3:
      name: 'Name3'
      surname: 'Surname3' 
      githubUsername: 'Name1gitUserName3'
    member4:
      name: 'Name4'
      surname: 'Surname4' 
      githubUsername: 'Name1gitUserName4'
```

- Donde, GrupoX puede ser GrupoA, GrupoB, o GrupoI, y Team es el nombre del equipo
    > Por ejemplo, el equipo "TheLeaders" matriculado en el GrupoI sería:
    >```yaml
    >name: 'ISII-2526-GrupoI-TheLeaders'
    >owner: 'GrupoI'
    >teamId: 'TheLeaders'
    >```

- Sustituir los datos de cada memberN por los del miembro real.
- Si el número de miembros es 3 entonces, eliminar member4 de la sección `members`.
- Modificar la cadena de `notifications.email` para que contengan sólo los correos @alu.uclm.es de todos los miembros separados por comas y sin espacios.

## 3. Unir el proyecto a la asignatura a la herramienta Bluejay

- Accede a [join.bluejay.governify.io](https://join.bluejay.governify.io).
- Añade la **URL del repositorio** de GitHub.
- Click en **CHECK**. Si ha dado error revisa la [sintaxis](https://www.yamllint.com/) del info.yml.
- **Selecciona la clase** a la que te quieres unir (ISII-2526) y especifica el código que te dará tu profesor.
- Click en **JOIN**.
- En caso de que haya algún otro problema al configurar Bluejay, el equipo de soporte está disponible en [un canal de Gitter dedicado](https://app.gitter.im/#/room/!VTAnLfNgxrEdydQgWd:gitter.im).


