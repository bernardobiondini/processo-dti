# DTI Project

# Execução do Projeto

Para executar o projeto é preciso instalar as dependências do Frontend e do Backend e depois executar

1. Instalando dependências Frontend:

```powershell
cd front/canil
```

```powershell
npm install
```

2. Executando Frontend

```powershell
npm run dev
```

3. Executando Backend

```powershell
cd back/canil
```

```powershell
dotnet run
```

- **A partir desse momento pode acesssar a url [http://localhost:3000/](http://localhost:3000/)**

# Sobre o desenvolvimento

Optei por fazer o backend utilizando .NET Core pois é uma tecnologia que tenho buscado conhecimento atualmente. C# permite trabalhar com classes de maneira muito simples o que facilitou o desenvolvimento.

Optei por criar uma classe PetShop que possuí os atributos específicos dos petshops mencionados (nome, distancia e preço dos banhos). Adicionei atributos para permitir diferença no preço nos finais de semana, um booleano que informa se o preço muda nessas condições e os preços em si, já acrescidos do valor referente.

Para a lógica em si utilizei o método Sort que permite ordenar o array de PetShops. Dessa forma, a primeira posição manteria a melhor opção para o cliente. Para isso utilizei o método Calculate da classe Petshop, que recebe a quantidade de cachorros e se é ou não final de semana. Além disso, optei por criar uma classe Budget para armazenar o preço final junto ao PetShop, para conseguir entregar ao cliente o valor do serviço.

Para o Frontend optei por fazer uma interface simples mas que utilizasse cores da DTI e utilizar o conceito de Estado para fazer a exibição das informações. Além disso, optei por utilizar a biblioteca axios para fazer a requisição.

Bernardo Cavanellas Biondini