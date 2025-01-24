# Aplicacion .Net Web API

### Construir la aplicación
dotnet build

### Ejecutar la aplicación
dotnet watch run

### Comandos de Dotnet
dotnet new webapi -n BaezStone.Demo01.Api -controllers --framework net9.0
dotnet sln list
dotnet watch run --launch-profile https
dotnet add reference ../BaezStone.Demo02.Data

### Comandos de Git
git config --global init.defaultBranch main => asigna la rama por defecto
git reset HEAD --  => deshacer los cambios y regresar al estado unstaged
git config --global core.editor "code --wait" => configurar el edito de comentarios
git commit --amend => permite editar el mensaje del ultimo commit
git reset --soft HEAD~1 => borrar el ultimo commit realizado
git log --stat => permite ver log detallado
git branch "implementacion-dto" => permite crear un branch
git branch => permite ver todos los branchs
git checkout implementacion-dto => permite cambiar de rama
git checkout -b feature/implementacion-dto => permite crear nueva rama 
git branch -D implementacion-dto => elimina una rama
git merge implementacion-dto => permite realizar merge
git log -p => muestra los cambios más detallados 
git merge --continue => para resolver los conflictos
git branch -M main => para crear y forzar la rama a crearse
git remote add origin https://github.com/djsilvab/BootcampGitHubNet.git => agregar rama remota
git remote -v => listar las ramas remotas
git push -u origin main => enviar y actualizar los cambios a la rama remota
git credential-cache exit => borrar credenciales de windows
git fetch origin
git pull -u origin main