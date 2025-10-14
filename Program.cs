//Feito por p218-dotcom (Primeiro codigo C# publicado no GitHub)

using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.Clear();
        List<string> alunos = new List<string>();
        List<decimal> notas = new List<decimal>();
        int escolha;

        do
        {
            Console.WriteLine("=========*=========");
            Console.WriteLine("1. Inserir aluno");
            Console.WriteLine("2. Inserir nota de aluno");
            Console.WriteLine("3. Remover nota e aluno");
            Console.WriteLine("4. Calcular médias");
            Console.WriteLine("5. Alterar nota do aluno");
            Console.WriteLine("6. Listar alunos e notas");
            Console.WriteLine("7. Sair");
            Console.WriteLine("===================");

            escolha = int.Parse(Console.ReadLine()!);

            if (escolha == 1)
            {
                Console.Clear();
                Console.WriteLine("Insira o nome do aluno: ");
                Console.WriteLine("=======================");
                Console.WriteLine("");
                Console.Write(">> ");
                string aluno = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(aluno))
                {
                    Console.WriteLine("Nenhum aluno foi adicionado. Pressione qualquer tecla para voltar()");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    alunos.Add(aluno);
                    Console.Clear();
                    Console.WriteLine($"'{aluno}' foi adicionado(a)\n");
                    Console.WriteLine("Pressione qualque tecla para voltar()");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            else if (escolha == 2)
            {
                Console.Clear();

                if (alunos.Count == 0)
                {
                    Console.WriteLine("Nenhum aluno cadastrado ainda!");
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("Escolha o aluno para adicionar a nota:");
                for (int i = 0; i < alunos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {alunos[i]}");
                }

                Console.Write("\nDigite o número do aluno: ");
                int indice = int.Parse(Console.ReadLine()!) - 1;

                if (indice < 0 || indice >= alunos.Count)
                {
                    Console.WriteLine("Aluno inválido! Pressione qualquer tecla para voltar...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.Write($"Digite a nota de {alunos[indice]}: ");
                decimal nota = decimal.Parse(Console.ReadLine()!);

                if (notas.Count > indice)
                    notas[indice] = nota;
                else
                    notas.Add(nota);

                Console.Clear();
                Console.WriteLine($"Nota {nota} adicionada para {alunos[indice]}!");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                Console.Clear();
            }


            else if (escolha == 3)
            {
                Console.Clear();
                Console.WriteLine("Insira o nome do aluno: ");
                Console.WriteLine("=======================");
                Console.WriteLine("");
                Console.Write(">> ");
                string aluno = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(aluno))
                {
                    Console.WriteLine("Nenhum aluno foi removido. Pressione qualquer tecla para voltar()");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    alunos.Remove(aluno);
                    Console.Clear();
                    Console.WriteLine($"'{aluno}' removido(a)\n");
                    Console.WriteLine("Pressione qualque tecla para voltar()");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            else if (escolha == 4)
            {
                Console.Clear();
                decimal soma = 0;
                int quantidade = 0;
                string input;

                Console.WriteLine("Digite as notas uma por vez.");
                Console.WriteLine("Quando terminar, digite 'fim'.\n");

                while (true)
                {
                    Console.Write("Nota: ");
                    input = Console.ReadLine()!;

                    if (input.ToLower() == "fim")
                        break;

                    if (decimal.TryParse(input, out decimal nota))
                    {
                        if (nota < 0 || nota > 10)
                            Console.WriteLine("Nota inválida! Deve ser entre 0 e 10.");
                        else
                        {
                            soma += nota;
                            quantidade++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Digite um número válido!");
                    }
                }

                if (quantidade == 0)
                {
                    Console.WriteLine("Nenhuma nota foi informada.");
                }
                else
                {
                    decimal media = soma / quantidade;
                    Console.WriteLine($"\nMédia: {media:F2}");
                    Console.WriteLine("Aperte qualquer tecla para volta()");
                    Console.ReadKey();
                    Console.Clear();

                    if (media >= 6)
                        Console.WriteLine("Aluno passou!");
                    else
                        Console.WriteLine("Aluno não passou!");
                }
            }
            else if (escolha == 5)
            {
                Console.Clear();

                if (alunos.Count == 0)
                {
                    Console.WriteLine("Nenhum aluno cadastrado!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("Escolha o aluno para alterar a nota:");
                for (int i = 0; i < alunos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {alunos[i]} - Nota: {notas[i]}");
                }

                Console.Write("\nDigite o número do aluno: ");
                int indice = int.Parse(Console.ReadLine()!) - 1;

                if (indice < 0 || indice >= alunos.Count)
                {
                    Console.WriteLine("Aluno inválido!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.Write($"Digite a nova nota para {alunos[indice]}: ");
                decimal novaNota = decimal.Parse(Console.ReadLine()!);

                notas[indice] = novaNota;

                Console.WriteLine($"Nota alterada com sucesso! Nova nota de {alunos[indice]}: {novaNota}");
                Console.ReadKey();
                Console.Clear();
            }
            else if (escolha == 6)
            {
                Console.WriteLine("Lista de todos os alunos: ");

                foreach (string aluno in alunos)
                {
                    Console.WriteLine($"> {aluno}");
                }
            }
            else if (escolha == 7)
            {
                break;
            }
        } while (escolha != 7);
    }
}