using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetosAuditoria;
using BDAuditorias;
using Excepcoes;
using RegrasNegocio;
/*  -------------------------------------------------
* <copyright file="Program.cs" company="IPCA"/>
* <summary>
*	Trabalho Prático LP2 2019-2020
*	José Dias       18840
*	Pedro Ferraz    18842
* </summary>
* <author>José Dias & Pedro Ferraz</author>
* <email
*   a18840@alunos.ipca.pt
*   a18842@alunos.ipca.pt
* </email>
* <desc>
*   Página principal deste programa
* </desc>
* -------------------------------------------------
*/

namespace ObjetosAuditoria
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Files
            //const string fileAuditorias = "auditoriasFile.bin";
            //const string fileVulnerabilidades = "vulnerabilidadesFile.bin";
            //const string fileColaboradores = "colaboradoresFile.bin";
            //const string fileEquipamentos = "equipamentosFile.bin";
            #endregion
            //RN.Load(fileAuditorias, fileVulnerabilidades, fileColaboradores, fileEquipamentos);
            #region DadosMain
            Colaborador jose = new Colaborador("Jose");
            Colaborador pedro = new Colaborador("Pedro");
            Colaborador luis = new Colaborador("Luis");
            Equipamento asusZenbook = new Equipamento("pc","asus","zenbook","25/04/2000");
            Equipamento hpElitebook = new Equipamento("pc", "hp", "elitebook", "01/04/2000");
            Vulnerabilidade va = new Vulnerabilidade("risco", Vulnerabilidade.Level.ELEVADO);
            Vulnerabilidade vb = new Vulnerabilidade("partido", Vulnerabilidade.Level.BAIXO);
            Auditoria b = new Auditoria(20, pedro, "21/06/2000"); 
            Auditoria c = new Auditoria(45, jose, "22/06/2000");
            Auditoria a = new Auditoria(15, jose, "20/06/2000");
            RN.InsereAuditoria(a);
            RN.InsereAuditoria(b);
            RN.InsereAuditoria(c);
            RN.InsereColaborador(jose);
            RN.InsereColaborador(pedro);
            RN.InsereColaborador(luis);
            RN.InsereVulnerabilidade(va);
            RN.InsereVulnerabilidade(vb);
            RN.InsereEquipamento(asusZenbook);
            RN.InsereEquipamento(hpElitebook);
            RN.InsereVulnerabilidadeAuditoria(b, vb);
            RN.InsereVulnerabilidadeAuditoria(c, va);
            RN.InsereVulnerabilidadeAuditoria(a, va);
            RN.InsereVulnerabilidadeAuditoria(a, vb);
            RN.InsereColaboradorAuditoria(a, jose);
            RN.InsereColaboradorAuditoria(b,pedro);
            RN.InsereColaboradorAuditoria(c,jose);
            RN.InsereVulnerabilidadeEquipamento(va,asusZenbook);
            RN.InsereVulnerabilidadeEquipamento(vb,hpElitebook);
            #endregion
            //RN.Save(fileAuditorias,fileVulnerabilidades,fileColaboradores,fileEquipamentos);
            RN.ApresentarDados();
            Console.ReadKey();
            RN.ResolveVulnerabilidade(va);
            RN.ApresentarDados();
            Console.ReadKey();






            #region Menu
            /*
            do
            {
                Console.Clear();
                Console.WriteLine("\n==============================================================================================");
                Console.WriteLine("                                            MENU                                                ");
                Console.WriteLine("==============================================================================================\n");
                Console.WriteLine("    > Quantidade de Auditorias realizadas:          {0} \n",                     Auditorias.TotalAuditorias());
                Console.WriteLine("    > Auditoria com MAIS vulnerabilidades:          {0}, {1} falha(s), ({2}) \n",Auditorias.AuditoriaMaisVulnerabilidades().Codigo.ToString(),
                                                                                                                    Auditorias.AuditoriaMaisVulnerabilidades().CodVulns.Count.ToString(),
                                                                                                                    Auditorias.AuditoriaMaisVulnerabilidades().Data.ToShortDateString());
                Console.WriteLine("    > Auditoria com MENOS vulnerabilidades:         {0}, {1} falha(s), ({2}) \n",Auditorias.AuditoriaMenosVulnerabilidades().Codigo.ToString(),
                                                                                                                    Auditorias.AuditoriaMenosVulnerabilidades().CodVulns.Count.ToString(),
                                                                                                                    Auditorias.AuditoriaMenosVulnerabilidades().Data.ToShortDateString());
                Console.WriteLine("    > Media de vulnerabilidades das auditorias:     {0} \n\n\n",                 Auditorias.MediaVulnerabilidades().ToString());
                Console.WriteLine("  1) Auditorias");
                Console.WriteLine("  2) Colaboradores");
                Console.WriteLine("  3) Vulnerabilidades");
                Console.WriteLine("  4) Equipamentos Informaticos");
                Console.WriteLine("  0) SAIR");
                Console.Write("  Escolha uma opcao: ");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n===============================================");
                        Console.WriteLine("                    Auditorias");
                        Console.WriteLine("===============================================\n");
                        Console.WriteLine("  1) Inserir Auditorias");
                        Console.WriteLine("  2) Remover Vulnerabilidades");
                        Console.WriteLine("  3) Auditorias Realizadas");
                        Console.WriteLine("  4) Vulnerabilidades Existentes");
                        Console.WriteLine("  0) MENU");
                        Console.Write("  Escolha uma opcao: ");
                        opcaoAux = int.Parse(Console.ReadLine());
                        switch (opcaoAux) 
                        {
                            case 1: //Inserir Auditoria
                                break;
                            case 2: //Remover Vulnerabilidades
                                break;
                            case 3: //Auditorias Realizadas
                                break;
                            case 4: //Vulnerabilidades Existentes
                                break;
                        }                    
                        break;
                    case 2:
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("\n===============================================");
                        Console.WriteLine("                   Colaboradores");
                        Console.WriteLine("===============================================\n");
                        Console.WriteLine("  1) Inserir Colaboradores");
                        Console.WriteLine("  2) Editar Colaboradores");
                        Console.WriteLine("  3) Remover Colaboradores");
                        Console.WriteLine("  4) Auditorias Realizadas por Colaborador");
                        Console.WriteLine("  0) MENU");
                        Console.Write("  Escolha uma opcao: ");
                        opcaoAux = int.Parse(Console.ReadLine());
                        switch (opcaoAux)
                        {
                            case 1: //Inserir Auditoria
                                break;
                            case 2: //Remover Vulnerabilidades
                                break;
                            case 3: //Auditorias Realizadas
                                break;
                            case 4: //Vulnerabilidades Existentes
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("\n===============================================");
                        Console.WriteLine("                    Vulnerabilidades");
                        Console.WriteLine("===============================================\n");
                        Console.WriteLine("  1) Inserir Vulnerabilidades");
                        Console.WriteLine("  2) Editar Vulnerabilidades");
                        Console.WriteLine("  0) MENU");
                        Console.Write("  Escolha uma opcao: ");
                        opcaoAux = int.Parse(Console.ReadLine());
                        switch (opcaoAux)
                        {
                            case 1: //Inserir Auditoria
                                break;
                            case 2: //Remover Vulnerabilidades
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("\n===============================================");
                        Console.WriteLine("                    Equipamentos");
                        Console.WriteLine("===============================================\n");
                        Console.WriteLine("  1) Inserir Equipamentos Informáticos");
                        Console.WriteLine("  2) Vulnerabilidades Identificadas");
                        Console.WriteLine("  0) MENU");
                        Console.Write("  Escolha uma opcao: ");
                        opcaoAux = int.Parse(Console.ReadLine());
                        switch (opcaoAux)
                        {
                            case 1: //Inserir Auditoria
                                break;
                            case 2: //Remover Vulnerabilidades
                                break;
                        }
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!!");
                        Console.ReadKey();
                        break;
                }
            } while (opcao != 0);
            */
            #endregion

        }
    }
}
