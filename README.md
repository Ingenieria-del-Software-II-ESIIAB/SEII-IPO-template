#[Instrucciones en Español](#instrucciones-para-utilizar-esta-plantilla).

#[Instructions in English](#instructions-to-use-this-template).

# Instrucciones para utilizar esta plantilla.

## 1. Cree la organización 

Cree el repositorio de su equipo con el nombre **ISII2526GrupoXYourName**, donde GrupoX puede ser GrupoA, GrupoB o GrupoI, siguiendo las instrucciones disponibles en:  
[Create an organization](https://docs.github.com/en/organizations/collaborating-with-groups-in-organizations/creating-a-new-organization-from-scratch).

## 2. Añada los miembros de su equipo a la organización

Añada a los miembros siguiendo las instrucciones disponibles en:  
[Inviting users to join your organization](https://docs.github.com/en/organizations/managing-membership-in-your-organization/inviting-users-to-join-your-organization).


## 3. Clone el repositorio

Cree el repositorio de su equipo con el nombre **ISII2526TeamName**, utilizando esta plantilla y 
siguiendo las instrucciones disponibles en:  
[Create a repository from a template](https://docs.github.com/es/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template#creating-a-repository-from-a-template).


## 4. Configure el repositorio de su equipo.

**4.1. En la rama development modificar el archivo `info.yml`.**

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

## 5. Unir el proyecto a la asignatura a la herramienta Bluejay

- Accede a [join.bluejay.governify.io](https://join.bluejay.governify.io).
- Añade la **URL del repositorio** de GitHub.
- Click en **CHECK**. Si ha dado error revisa la [sintaxis](https://www.yamllint.com/) del info.yml.
- **Selecciona la clase** a la que te quieres unir (ISII-2526) y especifica el código que te dará tu profesor.
- Click en **JOIN**.
- En caso de que haya algún otro problema al configurar Bluejay, el equipo de soporte está disponible en [un canal de Gitter dedicado](https://app.gitter.im/#/room/!VTAnLfNgxrEdydQgWd:gitter.im).

# Instructions to use this template.

## 1. Create the organisation

Create your team's repository with the name **ISII2526GroupXYourName**, where GroupX can be GroupA, GroupB, or GroupI, following the instructions available at:  
[Create an organisation](https://docs.github.com/en/organizations/collaborating-with-groups-in-organizations/creating-a-new-organization-from-scratch).

## 2. Add your team members to the organisation

Add members by following the instructions available at:  
[Inviting users to join your organisation](https://docs.github.com/en/organizations/managing-membership-in-your-organization/inviting-users-to-join-your-organization).

## 3. Clone the repository

Create your team's repository with the name **ISII2526TeamName**, using this template and 
following the instructions available at:  
[Create a repository from a template](https://docs.github.com/es/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template#creating-a-repository-from-a-template).

## 4. Configure your team's repository.

**4.1. In the development branch, modify the `info.yml` file.**

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

- Where GroupX must be GroupI, and Team is the name of the team
    > For example, the team ‘TheLeaders’ registered in GroupI would be:
    >```yaml
    >name: 'ISII-2526-GrupoI-TheLeaders'
    >owner: 'GroupI'
    >teamId: 'TheLeaders'
    >```
- Replace the data for each memberN with that of the actual member.
- If the number of members is 3, delete member4 from the `members` section.
- Modify the `notifications.email` string so that it only contains the @alu.uclm.es email addresses of all members, separated by commas and without spaces.

## 5. Link the project to the course using the Bluejay tool

- Go to [join.bluejay.governify.io](https://join.bluejay.governify.io).
- Add the GitHub **repository URL**.
- Click on **CHECK**. If you get an error, check the [syntax](https://www.yamllint.com/) of the info.yml.