using System;
using System.Collections.Generic;

namespace BikeShareSP
{
    class Program
    {
        // Estrutura de dados simples para simular o banco de dados (UC1)
        static List<string> bicicletas = new List<string>
        {
            "Caloi City - ID 001",
            "Monark Urban - ID 002"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("=== BikeShare SP - Sistema de Gestão (Versão Alpha) ===");

            bool emExecucao = true;

            while (emExecucao)
            {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("1 - Listar Bicicletas Disponíveis [REQ-01]");
                Console.WriteLine("2 - Cadastrar Nova Bicicleta [REQ-02]");
                Console.WriteLine("3 - Realizar Aluguel [REQ-03]");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarBikes();
                        break;

                    case "2":
                        CadastrarBike();
                        break;

                    case "3":
                        RealizarAluguel();
                        break;

                    case "0":
                        emExecucao = false;
                        Console.WriteLine("Encerrando sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        // [REQ-01]
        static void ListarBikes()
        {
            Console.WriteLine("\n--- Bicicletas no Sistema ---");

            foreach (var bike in bicicletas)
            {
                Console.WriteLine($"- {bike}");
            }
        }

        // [REQ-02] Cadastro Dinâmico
        static void CadastrarBike()
        {
            Console.Write("\nDigite o nome da nova bicicleta: ");

            string novaBike = Console.ReadLine();

            // Validação para impedir cadastro vazio
            if (!string.IsNullOrWhiteSpace(novaBike))
            {
                bicicletas.Add(novaBike);

                Console.WriteLine("Bicicleta cadastrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro: o nome da bicicleta não pode ser vazio.");
            }
        }

        // [REQ-03] Sistema de Aluguel
        static void RealizarAluguel()
        {
            Console.Write("\nDigite o nome da bicicleta para aluguel: ");

            string bikeAlugada = Console.ReadLine();

            bool encontrada = false;

            // Busca usando LOOP FOR
            for (int i = 0; i < bicicletas.Count; i++)
            {
                if (bicicletas[i].Equals(bikeAlugada, StringComparison.OrdinalIgnoreCase))
                {
                    bicicletas.RemoveAt(i);

                    encontrada = true;

                    Console.WriteLine("Bicicleta alugada com sucesso!");
                    break;
                }
            }

            // Caso não encontre
            if (!encontrada)
            {
                Console.WriteLine("Erro: bicicleta não encontrada.");
            }
        }
    }
}