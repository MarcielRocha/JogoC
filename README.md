# JogoC
Projeto Final - Parte 1
Desenvolva o minigame chamado Jewel Collector. O objetivo desse jogo é que um robô, controlado pelo teclado, se desloque por um mapa 2D de modo a desviar dos obstáculos e coletar todas as joias. Para isso, as seguintes classes devem ser criadas:

Jewel.cs - A classe Jewel deverá armazenar as informações da joia, como a posição (x, y) no mapa e o tipo, que poderá ser Red, no valor de 100 pontos; Green, no valor de 50 pontos; e Blue, no valor de 10 pontos.
Obstacle.cs - A classe Obstacle deverá armazenar as informações do obstáculo, que será a posição (x, y) e o tipo. Cada obstáculo deverá possuir um tipo, que poderá ser Water ou Tree.
Robot.cs - A classe Robot deverá ser responsável por armazenar as informações do robô, que será a posição (x, y) e uma sacola (bag), em que o robô colocará as joias coletadas no mapa. Além disso, a classe Robot deverá implementar os métodos para que o robô possa interagir com o mapa, isto é, deslocar-se nas quatro direções e coletar as joias. Além disso, implemente um método para imprimir na tela o total de joias armazenadas na sacola e o valor total.
Map.cs - A classe Map deverá armazenar as informações do mapa 2D e implementar métodos para adição e remoção de joias e obstáculos. Além de um método para imprimir o mapa na tela. A impressão do mapa deverá seguir a seguinte regra: Robo será impresso como ME; Joias Red, como JR; Joias Green, como JG; Joias Blue, como JB; Obstáculos do tipo Tree, como $$; Obstáculos do tipo Water, como ##; Espaços vazios, como --.
JewelCollector.cs - A classe JewelCollector deverá ser responsável por implementar o método Main(), criar o mapa, inserir as joias, obstáculos, instanciar o robô e ler os comandos do teclado. Para que o usuário possa controlar o robô, os seguintes comandos deverão ser passados através das teclas w, s, a, d, g. Sendo que a tecla w desloca o robô para o norte, a tecla s desloca para o sul, a tecla a desloca para oeste e a tecla d para leste. Para coletar uma joia, use a tecla g.
Uma joia somente poderá ser coletada se o robô estiver em uma das posições adjacentes a ela. Todos os obstáculos são intransponíveis. Para cada comando executado pelo usuário, imprima o estado atual do mapa, bem como o estado da sacola do robô.

Observação: Caso julgue necessário para uma melhor estruturação do código, é permitido criar classes adicionais.

Projeto Final - Parte 2
Desenvolva o minigame Jewel Collector 2.0, implementado previamente na aula 2. O objetivo dessa nova versão é melhorar o código anterior através da implementação dos novos conceitos e recursos aprendidos até o momento. Cada classe deve estar em um arquivo separado, com o nome NomedaClasse.cs. Particularmente, os seguintes recursos DEVEM NECESSARIAMENTE ser utilizados:

Devem ser usados, tanto arrays como alguma instância de uma Collection (a seu critério)
Mecanismo de Eventos para captura dos eventos de teclado e visualização do mapa no console
Geração de Documentação Automática: Todas as classes, os métodos públicos das classes utilizadas, bem como os fields públicos devem ser comentados e incluídos na documentação gerada.

Utilizei as sugestões do projeto https://github.com/leolellisr/inf0990_final_project_csharp.git nas classes de tratamento de erro, navegação do robô e jóias.
