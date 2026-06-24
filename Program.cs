//Screen Sound


using System;
using System.Runtime.InteropServices.Marshalling;
using System.Threading;


string msgDeBoasVindas = "Boas Vindas ao Screen Sound";
//List<string> listasDasBandas = new List<string>{"Limp Bizit", "Deftones", "Korn", "Slipknot"};

Dictionary<string, List<int>> bandasRgistradas = new Dictionary<string, List<int>>();
bandasRgistradas.Add("Limp Bizkit", new List<int>());
bandasRgistradas.Add("Korn", new List<int>{10, 9, 8});


/*ExibirLogo();*/
ExibirOpcoesDoMenu();

/// <summary>
/// Exibe o logo do Screen Sound e a mensagem de boas vindas.
/// </summary>
void ExibirLogo()
{
    
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");

    Console.WriteLine(msgDeBoasVindas);
}    
/// <summary>
/// Exibe as opções do menu para o usuário escolher a ação desejada.
/// </summary>
///    
void ExibirOpcoesDoMenu()
{
    ExibirLogo();    
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair\n");

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBandas();

        break;

        case 2: MostrarBandas();

        break;
        
        case 3: AvaliarUmaBanda();

        break;
        
        case 4: ExibirMediaDaBanda();

        break;

        case 0: Console.WriteLine("Obrigado por utilizar o Screen Sound!\n");

        break;

        default: Console.WriteLine("Opção inválida!");
                Thread.Sleep(2000); //Aguarda 2 segundos
                ExibirOpcoesDoMenu();
        break;

    }

}
/// <summary>
/// Exibe a média de uma banda registrada na lista.
/// </summary>
void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo a média de uma banda");
    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    
    if(bandasRgistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRgistradas[nomeDaBanda];
        double media = notasDaBanda.Average(); //média da nota da banda

        Console.WriteLine($"\nA média da banda {nomeDaBanda} é: {media}");
        Console.WriteLine("\nDigite algo para voltar o menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não está registrada.");
        Console.WriteLine("Digite algo para voltar o menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
  

}

/// <summary>
/// Permite ao usuário avaliar uma banda registrada na lista.
/// </summary>
void AvaliarUmaBanda()
{
    
    Console.Clear();

    ExibirTituloDaOpcao("Avaliar uma banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");

    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRgistradas.ContainsKey(nomeDaBanda))
    {
        
        Console.Write($"Qual a nota que você deseja dar para a banda {nomeDaBanda}? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRgistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
        Thread.Sleep(5000); //Aguarda 5 segundos
        Console.Clear();
        ExibirOpcoesDoMenu();
     
    }    
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não está registrada.");
        Console.WriteLine("Digite algo para voltar o menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    
}



/// <summary>
/// Exibir o título da opção escolhida pelo usuário.
/// </summary>
/// <param name="titulo">Título da opção escolhida pelo usuário.</param>
void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");

}

/// <summary>
/// Registrar uma banda na lista de bandas.
/// </summary>
void RegistrarBandas()
{
    Console.Clear(); //limpa a tela
    ExibirTituloDaOpcao("Registros das Bandas"); 

    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRgistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com êxito!");
    Thread.Sleep(2000); //Aguarda 2 segundos
    Console.Clear();
    ExibirOpcoesDoMenu();

}

/// <summary>
/// Exibe as bandas registradas na lista.
/// </summary>
void MostrarBandas()
{
    
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    

    // for (int i = 0; i < listasDasBandas.Count; i++)
    // {
    //     Console.WriteLine($"Banda {i}: {listasDasBandas[i]}");
    // }

    foreach (string banda in bandasRgistradas.Keys)
    {
          Console.WriteLine($"Banda:  {banda}");
    }

    Console.WriteLine("\nDigite algo para voltar o menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}