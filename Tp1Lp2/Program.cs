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
            #region Main
            Colaborador jose = new Colaborador("Jose");
            Colaborador pedro = new Colaborador("Pedro");
            Colaborador luis = new Colaborador("Luis");
            Equipamento asusZenbook = new Equipamento("pc","asus","zenbook","25/04/2000");
            Equipamento hpElitebook = new Equipamento("pc", "hp", "elitebook", "01/04/2000");
            Vulnerabilidade va = new Vulnerabilidade("falha na rede", Vulnerabilidade.Level.ELEVADO);
            Vulnerabilidade vb = new Vulnerabilidade("cabo rasgado", Vulnerabilidade.Level.BAIXO);
            Vulnerabilidade vc = new Vulnerabilidade("falha eletrica", Vulnerabilidade.Level.MODERADO);
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
            RN.InsereVulnerabilidade(vc);
            RN.InsereEquipamento(asusZenbook);
            RN.InsereEquipamento(hpElitebook);
            RN.InsereVulnerabilidadeAuditoria(b, vb);
            RN.InsereVulnerabilidadeAuditoria(c, va);
            RN.InsereVulnerabilidadeAuditoria(c, vc);
            RN.InsereVulnerabilidadeAuditoria(a, va);
            RN.InsereVulnerabilidadeAuditoria(a, vb);
            RN.InsereVulnerabilidadeAuditoria(a, vc);
            RN.InsereColaboradorAuditoria(a, jose);
            RN.InsereColaboradorAuditoria(b,pedro);
            RN.InsereColaboradorAuditoria(c,jose);
            RN.InsereVulnerabilidadeEquipamento(va,asusZenbook);
            RN.InsereVulnerabilidadeEquipamento(vc, asusZenbook);
            RN.InsereVulnerabilidadeEquipamento(vb,hpElitebook);
            RN.InsereVulnerabilidadeEquipamento(vc,hpElitebook);
            #endregion
            //RN.Save(fileAuditorias,fileVulnerabilidades,fileColaboradores,fileEquipamentos);
            RN.ApresentarDados();
            Console.ReadKey();
            ///Teste de alguns metodos de manipulação do programa
            /// > Resolver a vulnerabilidade (va)
            /// > Altera o estado do colaborador Luis para INATIVO
            RN.ResolveVulnerabilidade(va);
            RN.ResolveColaborador(luis);
            RN.ApresentarDados();
            Console.ReadKey();
        }
    }
}
