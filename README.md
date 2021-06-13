# UNIT S2 LD39 Reloaded #
### por Daniel "Hartax" Costa
#### [www.danielhartax.com](http://www.danielhartax.com "www.danielhartax.com")

<br><br>

# Bugs conhecidos corrigidos. 

- O bug da porta era pq as portas não estavam com o atributo **IsTrigger** do collider ativados tendo em vista que a classe delas eram com base em **OnTriggerEnter** para disparar a ação. Setei pra true os atributos e elas voltaram a funcionar.

- Achei um erro que não estava listado. No primeiro inimigo,  ele não estava atirando. O console apontou que não tinha prefab definido para tiro. Reconfigurei o mesmo, atribuindo o prefab bullet do projeto, para solucionar isso mas de qualquer forma ele tava grifado que estava fora do padrão do prefab original. Usar o restaurar o prefab resolveria o problema da mesma forma.

- O shock não estava funcionando pq na classe **ShockDamageArea**  o objeto do tipo **AIAgent**  instanciada estava passando o valor **0** para o método **OnShock**. Troquei o **0** pelo atributo **stunTime**.

- A principio aqui não "engasgou" nada mas como você disse que tava engasgando algo, fui pesquisar no código. Já que foi algo colocado intecionalmente, imaginei que fosse algo que rodasse em determinado intervalo de tempo. Então, fazendo uma busca por **Time.deltaTime** achei o objeto Spin com uma routine pesada toda vida com direito ao recadinho deixado por você *"Isso aqui é só para te causar problema"* :tw-1f60b: Com isso, só foi achar na cena o objeto que estava com esse script atrelado. Era o **Cube (5)**. Um cubo flutuante aleatório na cena no meio do nada. Exclui ele e ficou tudo certo.

<br><br>
# Feats requisitadas que foram implementadas

### Atirar

- Setei no input a tecla **Q** para atirar.

- Criei o **Shoot** na lista de possíveis updates.

- Criei o atributo publico **fireCost** na classe **StealthPlayerControle** para definir o custo do tiro no inspetor do editor. Se nao tiver energia o suficiente para atirar, é dado um alerta sobre isso aproveitando a classe **ConsoleText** do projeto.

- Na mesma classe, criei o metodo **PlayerFire** que usa o metodo **Fire** da herança e adiciona umas funções extras.

- O prefab do tiro do player é diferente do tiro do inimigo. Utilizei os atributos da classe **DamageArea** para mudar a velocidade do tiro do player.

- Na classe **DamageArea**, eu modifiquei o **OnTriggerEnter** pra fazer um teste. Se for inimigo atirando no Player, executam as ações que já existiam no projeto. Caso seja o contrário, chama o método, que eu criei, chamado **ShutDown**, na classe **AiAgent**, que desliga o inimigo.

- Os tiros não estão mais passando pelas paredes. Implementei teste de **Raycast** com base na layer **Scenario**. Se bater nela, destroy o tiro.

- Por causa do Raycast, retirei o **OnColissionEnter** da classe pois estava sem função.


### Hover

- Fiz uma o uma função no **Update** que mantem voando caso mantenha o espaço pressionado com uma altura limite para ficar flutuando.

- Seguindo o padrão do projeto, criei o **boolean floating**, o atributo **floatingEnergyMultiplier** e segui o mesmo padrão de drenagem de energia com base nos status fazendo verificacao no **enableEnergyDrain**

- Adicionei particulas para efeito quando estiver flutuando e efeito sonoro para o mesmo.

- Você tem que flutuar para passar por cima de piscinas de ácido que eu criei no projeto. 


### Boss

- Boss adicionado com campo de força com a classe **Shield**. no atributo **resistencia**, do campo de força, vc atribui a quantidade de hits necessários para distruir o escudo. 

- Criado a classe **Boss** com funcionalidades para o mesmo.

- O atributo **dissolve** do shader do escudo é mudado, a cada tiro, de forma proporcional ao nivel de resistencia definido. 

- Destruindo o escudo, o chefe morre caso você de mais um hit nele. 

- O Boss dropa a última chave e você consegue abrir a ultima porta. 

- Mudei na classe **DamageArea** a velocidade e o dano do tiro do boss.

- O angulo de visao dele e a distancia que eles pode ver o jogador foi alterado na classe **EnemySight**

- O tiro do Boss da menos dano para equilibrar com o fato do boss ter escudo o que faz com que demore mais pra morrer. 

- Você precisa lidar com a perda de energia, atirar, o que tambem faz perder energia,e desviar dos ataques do boss.

- Quando ele morre, vc continua perdendo energia. tem que conseguir pegar a chave e sair antes que a energia acabe. Se depois de vc matar o boss vc morrer por falta de energia, o boss volta na hora que você respawnar. **Padrao Dark Souls de qualidade.**


## Outras alterações no projeto

- A classe **Door** foi alterada pra suportar portas largas com vários cubos.

- Troquei o cubo vermelho dos updates por um cubo estilizado.

- Refiz as particulas do **drain**, com um script **DrainEffect** controlando o linerender do drain, **tiro**, **upgrade**, **start**, **bateria**, **correr**, **andar**, **checkpoint** e **shock**,

- Quando se esconde dentro de uma caixa, a particula eu deixei so na entrada da caixa e alem disso botei para o player ficar um shader de ver atraves da parede para ver o personagem dentro da caixa. 

- Mudei o shader do cloak para um transparente com outline. 

- Cenário ajustado com a região do Boss.

- Refiz o **Navmesh**

- Troca de efeitos sonoros diversos.

- Troquei a textura do cenário.

- Adicionei HUD das funcionalidades novas seguindo o padrão do projeto

- Configurei luz e post processing nas 3 cenas.

- Adicionei musica na cena de **inicio** e de **fim**.

- Mudei o Loading de cenário pra **Async** e fiz uma tela de **Loading** utilizando um vídeo gerado dentro do Unity com o **Unity Recorder**.

### Done
